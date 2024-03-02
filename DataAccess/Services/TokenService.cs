using DataAccess.Models.Auth;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DataAccess.Services;

public class TokenService
{
    //Issuer  = nom api
    //audience = site appelant l'api
    //secret =  clé secrete
    private readonly string _issuer, _audience, _secret;
    JwtSecurityToken token = new JwtSecurityToken();
    IMemoryCache _memory;
    public TokenService(IConfiguration config, IMemoryCache memoryCache)
    {
        _memory = memoryCache;
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
        //On controle si il y'a un token sur l'id 
        if(_memory.TryGetValue(user.Id.ToString(), out string tokens))
        {
            // si le token est dans le cache alors il n'à pas expiré
            return tokens;
        }
        //Ici pas de token dans le cache ou le token a expiré 
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
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        string SendToken = handler.WriteToken(token);
        _memory.Set(user.Id.ToString(), SendToken, new MemoryCacheEntryOptions().SetAbsoluteExpiration(token.ValidTo));
        return SendToken;

    }

}
