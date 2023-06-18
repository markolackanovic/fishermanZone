using Domain.Entities;

namespace Application.Authentification
{
    public interface IJwtProvider
    {
        public Task<string> GenerateTokenAsync(Korisnik korisnik);
    }
}
