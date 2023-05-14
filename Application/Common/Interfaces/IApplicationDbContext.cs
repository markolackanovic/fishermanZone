using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        IModel Model { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}