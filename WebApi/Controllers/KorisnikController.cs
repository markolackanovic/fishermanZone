using Application.BusinessLogic.Korisnik.Commands.Create;
using Application.Common.Enums;
using Application.Common.Infrastructure.Settings;
using Application.Common.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Authorize]
    public class KorisnikController : ApiBaseController
    {
        public KorisnikController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Korisnik" })]
        public async Task<ActionResult<int>> Add(CreateKorisnikCommand request)
        {
            var passHasher = new PasswordHasher(new OptionsWrapper<HashingOptions>(new HashingOptions()));
            request.Lozinka = passHasher.Hash(request.Lozinka);

            return Ok(await Mediator.Send(request));
        }
    }
}
