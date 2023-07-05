using Application.Common.Interfaces;
using Application.Shared.Policy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Dokument.Policy
{
    public class DokumentPolicy : BasePolicy
    {
        private readonly IApplicationDbContext _context;

        public DokumentPolicy(IApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task<bool> CanDeleteAsync(ClaimsPrincipal claims, int Id)
        {
            var loggedUserId = Int16.Parse(claims.FindFirst(ClaimTypes.Name)?.Value);
            var userId = await _context.Set<Domain.Entities.Dokument>()
                            .Where(x => x.DokumentId == Id
                           //    && x.KorisnikId == loggedUserId
                                && x.Aktivno == true)
                            .FirstOrDefaultAsync();
            return userId != null;
        }
    }
}

