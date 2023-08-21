using DataAccess.Models.Auth;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DataAccess.Services
{
    public class TokenService
    {
        
        //Issuer  = nom api
        //audience = site appelant l'api
        //secret =  clé secrete
        private readonly string _issuer, _audience, _secret;
        private readonly IMemoryCache _memoryCache;
        JwtSecurityToken token = new JwtSecurityToken();
        public TokenService(IConfiguration config, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _issuer = config.GetSection("tokenValidation").GetSection("issuer").Value;
            _audience = config.GetSection("tokenValidation").GetSection("audience").Value;
            _secret = config.GetSection("tokenValidation").GetSection("secret").Value;
        }
        
        public string GenerateJwt(ConnectedForm user)
        {
            if (!_memoryCache.TryGetValue("Token", out token))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));

                if (user == null)
                {
                    throw new ArgumentNullException();
                }

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                Claim[] myClaims = new Claim[]
                {
                new Claim(ClaimTypes.Surname, user.SurName),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
                };

                token = new JwtSecurityToken
                (
                    claims: myClaims,
                    signingCredentials: credentials,
                    issuer: _issuer,
                    audience: _audience,
                    expires: DateTime.Now.AddHours(8)

                );

                _memoryCache.Set("Token", token, cacheEntryOptions);
                Console.WriteLine(token);
            }
            Console.WriteLine("ok token");
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);

        }
        
    }
}
