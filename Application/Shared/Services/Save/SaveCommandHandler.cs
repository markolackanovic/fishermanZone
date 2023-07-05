using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Save
{
    public class SaveCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, int>
        where TCommand : SaveCommand
        where TEntity : class, new()
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SaveCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.Id == 0)
            {
                var entity = _mapper.Map<TCommand, TEntity>(request);
                var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                    .Select(x => x.Name)
                    .Single();

                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync(cancellationToken);


                return (int)entity.GetType().GetProperty(keyName).GetValue(entity);
            }
            else {
                var entity = _mapper.Map<TCommand, TEntity>(request);
                var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                    .Select(x => x.Name)
                    .Single();

                _context.Set<TEntity>().Update(entity);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                    return (int)entity.GetType().GetProperty(keyName).GetValue(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}

