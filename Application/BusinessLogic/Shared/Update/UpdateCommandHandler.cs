using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.BusinessLogic.Shared.Update
{
    public class UpdateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand>
        where TCommand : UpdateCommand
        where TEntity : class, new()
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TCommand, TEntity>(request);
            _context.Set<TEntity>().Update(entity);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
