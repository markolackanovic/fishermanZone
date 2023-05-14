using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.BusinessLogic.Shared.Create
{
    public class CreateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand>
        where TCommand : ICreateCommand
        where TEntity : class, new()
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TCommand, TEntity>(request);
            _context.Set<TEntity>().Add(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
