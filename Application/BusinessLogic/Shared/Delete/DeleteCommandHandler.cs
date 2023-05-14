using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Shared.Delete
{
    public class DeleteCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand>
        where TCommand : IDeleteCommand
        where TEntity : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Set<TEntity>().Find(request.Id);
            try
            {
                entity.GetType().GetProperty("Aktivno").SetValue(entity, false);

            }
            catch (Exception e)
            {

                throw e;
            }                
            // postaiti vrijednost atribut active na false
            _context.Set<TEntity>().Update(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
