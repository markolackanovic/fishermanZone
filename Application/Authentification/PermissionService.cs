using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace Application.Authentification
{
    public class PermissionService : IPermissionService
    {
        private readonly IApplicationDbContext _context;

        public PermissionService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HashSet<string>> GetPermissionsAsync(int userId)
        {

            var roles = await _context.Set<Korisnik>()
                .Include(x => x.UlogaKorisnika)
                .ThenInclude(x => x.OvlascenjeUloges)
                .Where(x => x.KorisnikId == userId)
                .Select(x => x.UlogaKorisnika)
                .SelectMany(x => x.OvlascenjeUloges)
                .Select(x => x.Ovlascenje)
                .Select(x => x.Naziv)
                .ToArrayAsync();

            return roles.ToHashSet();
        }
    }  
}
