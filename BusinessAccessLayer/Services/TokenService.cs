using BusinessAccessLayer.Models.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class TokenService
    {
        //Issuer  = nom api
        //audience = site appelant l'api
        //secret =  clé secrete
        private readonly string _issuer, _audience, _secret;

        public TokenService(IConfiguration config)
        {
            _issuer = config.GetSection("tokenValidation").GetSection("issuer").Value;
            _audience = config.GetSection("tokenValidation").GetSection("audience").Value;
            _secret = config.GetSection("tokenValidation").GetSection("secret").Value;
        }

        public string GenerateJwt(ConnectedForm user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myClaims = new Claim[] 
            {
                new Claim(ClaimTypes.Surname, user.SurName),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken token = new JwtSecurityToken
            (
                claims: myClaims,
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience,
                expires : DateTime.Now.AddHours(8)

            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);

        }
        
    }
}
