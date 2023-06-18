using Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword;
using Domain.Entities;

namespace Application.Authentification
{
    public interface IJwtProvider
    {
        public Task<string> GenerateTokenAsync(LoggedUserViewModel korisnik);
    }
}
