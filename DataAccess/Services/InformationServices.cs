using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{


    public class InformationServices : IInformationServices
    {
        private readonly SecurityCompanyContext _DbContext;

        public InformationServices(SecurityCompanyContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Role> GetAllRoles()
        {
            List<Role> roles = _DbContext.Roles
                .Select((roles) => new Role { roleId = roles.roleId, Name = roles.Name, DiminName = roles.DiminName }).ToList();
            return roles;
        }
    }
}
