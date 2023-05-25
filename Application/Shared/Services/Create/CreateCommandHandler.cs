using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Shared.Services.Create
{
    public class CreateCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, int>
        where TCommand : CreateCommand
        where TEntity : class, new()
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TCommand, TEntity>(request);
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
                .Select(x => x.Name)
                .Single();
            _context.Set<TEntity>().Add(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return (int)entity.GetType().GetProperty(keyName).GetValue(entity);


            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
