﻿using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly SecurityCompanyContext _db;
        private readonly TokenService _toTokenService;

        public AuthServices(SecurityCompanyContext context, TokenService toTokenService)
        {
            _db = context;

            _toTokenService = toTokenService;
        }

        public string RegisterEmployee(AddRegisterForm form)
        {
            if (form == null)
                return "Formumaire Vide";

            var pLogin = new SqlParameter("Login", form.Login);
            var pPassword = new SqlParameter("Password", form.Password);
            var pId = new SqlParameter("Id", form.Id);

            var requete = _db.Users.Select(client => client.Login);
            foreach (var user in requete)
            {
                if(user == form.Login)
                {
                    return ("Login déjà utilisé");
                }
            }
            try
                    {
                        _db.Database.ExecuteSqlRaw($"EXEC dbo.RegisterAccessEmployee @Login, @Password, @Id ", pLogin, pPassword, pId);
                        return "Created";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }

        public ConnectedForm Login(LoginForm form)
        {
            var pLogin = new SqlParameter("Login", form.Login);
            var pPassword = new SqlParameter("Password", form.Password);
            try
            {
                List<ConnectedForm> response = _db.Set<ConnectedForm>().FromSqlRaw($"EXEC dbo.Loginemployee @Login, @Password", pLogin, pPassword).ToList();
                ConnectedForm user  = response.FirstOrDefault();
                user.Token = _toTokenService.GenerateJwt(user);
                return user;
            }
            catch (Exception)
            {
                return new ConnectedForm();
            }

        }
    }
}
