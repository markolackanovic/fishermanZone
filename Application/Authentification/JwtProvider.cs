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
        private readonly JwtOptions _options;
        private readonly IPermissionService _permissionService;
        private readonly IConfiguration _configuration;
        public JwtProvider(IOptions<JwtOptions> options, IPermissionService permissionService, IConfiguration configuration)
        {
            _options = options.Value;
            _permissionService = permissionService;
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(Korisnik korisnik)
        {
            var claims = new List<Claim> { 
                new (JwtRegisteredClaimNames.Sub,korisnik.KorisnikId.ToString()),
                new (JwtRegisteredClaimNames.Sub,korisnik.KorisnickoIme),
                new (JwtRegisteredClaimNames.Sub,korisnik.UlogaKorisnikaId.ToString())
            };

            HashSet<string> permissions = await _permissionService.GetPermissionsAsync(korisnik.KorisnikId);


            foreach(var permission in permissions)
            {
                claims.Add(new(CustomClaims.Permissions, permission));
            }

            var signingCredidential = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value.ToString())),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddDays(30),
                signingCredidential);
            var tokenValue =  new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
