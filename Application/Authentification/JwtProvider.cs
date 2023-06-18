using Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword;
using Application.Common.Infrastructure.Settings;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Authentification
{
    public class JwtProvider : IJwtProvider
    {
        private readonly AppSettings _options;
        private readonly IPermissionService _permissionService;
        private readonly IConfiguration _configuration;
        public JwtProvider(IOptions<AppSettings> options, IPermissionService permissionService, IConfiguration configuration)
        {
            _options = options.Value;
            _permissionService = permissionService;
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(LoggedUserViewModel korisnik)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, korisnik.KorisnikId.ToString()),
                    new Claim(CustomClaims.Role, korisnik.UlogaKorisnikaId.ToString()),
                    new Claim(CustomClaims.Association, korisnik.UdruzenjeId.ToString())
            };

            HashSet<string> permissions = await _permissionService.GetPermissionsAsync(korisnik.KorisnikId);


            foreach(var permission in permissions)
            {
                claims.Add(new(CustomClaims.Permissions, permission));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(Convert.ToInt16(_options.TokenDurationDays)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
