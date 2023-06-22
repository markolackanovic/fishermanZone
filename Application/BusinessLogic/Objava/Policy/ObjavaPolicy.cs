using Application.Common.Interfaces;
using Application.Shared.Policy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Objava.Policy
{
    public class ObjavaPolicy : BasePolicy
    {
        private readonly IApplicationDbContext _context;

        public ObjavaPolicy(IApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task<bool> CanDeleteAsync(ClaimsPrincipal claims, int Id)
        {
            var loggedUserId = Int16.Parse(claims.FindFirst(ClaimTypes.Name)?.Value);
            var userId = await _context.Set<Domain.Entities.ObjavaKorisnika>()
                            .Where(x => x.ObjavaId == Id 
                                && x.KorisnikId == loggedUserId
                                && x.Objava.Aktivno == true)
                            .FirstOrDefaultAsync();
            return userId != null;
        }
    }
}
