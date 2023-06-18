using Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword;
using Application.Common.Infrastructure.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.Login
{
    [Authorize]
    public class LoginController : ApiBaseController
    {
        public LoginController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Login" })]
        public async Task<ActionResult<LoggedUserViewModel>> Login(GetKorisnikByUsernameAndPasswordQuery data)
        {
            return Ok(await Mediator.Send(data));
        }
    }
}
