using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Policy
{
    public class BasePolicy
    {
        public virtual async Task<bool> CanAddAsync(ClaimsPrincipal claims, int id)
        {
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> CanDeleteAsync(ClaimsPrincipal claims, int id)
        {
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> CanGetAsync(ClaimsPrincipal claims, int id)
        {
            return await Task.FromResult(true);
        }

        public virtual async Task<bool> CanUpdateAsync(ClaimsPrincipal claims, int id)
        {
            return await Task.FromResult(true);
        }
    }
}
