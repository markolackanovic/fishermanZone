using Application.Common.Infrastructure.Settings;
using Application.Common.Interfaces;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class ApiBaseController : ControllerBase
    {
        public readonly IOptions<AppSettings> _appSettings;


        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public ApiBaseController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;

        }

        protected string CreateToken(int korisnikId, int ulogaKorisnikaId,  int udruzenjeId)
        {
            string retValue = string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, korisnikId.ToString()),
                    new Claim("ulogaKorisnikaId", ulogaKorisnikaId.ToString()),
                    new Claim("udruzenjeId", udruzenjeId.ToString())
                }),
                Expires = DateTime.Now.AddDays(Convert.ToInt16(_appSettings.Value.TokenDurationDays)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            retValue = tokenHandler.WriteToken(token);

            return retValue;
        }

        protected void WriteFileToDisk(string guidFileName, string fileBase64) {
            //var path = Path.Combine(_appSettings.Value.ImagesFolder, guidFileName);
            var path = Path.Combine("C:\\Users\\pero.novakovic\\test", guidFileName);

            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(fileBase64));
        }
    }
}
