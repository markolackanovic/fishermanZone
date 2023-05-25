using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Services.Queries.GetByID
{
    public class GetByIdQueryHandler<TViewModel, TQuery, TEntity> : IRequestHandler<TQuery, TViewModel>
        where TViewModel : class
        where TQuery : GetByIdQuery<TViewModel>
        where TEntity : class

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .SingleOrDefault();
            if (keyName == null)
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            var result = await _context.Set<TEntity>()
                .Where(ExpressionHelper.CreateExpression<TEntity>(keyName, request.Id))
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            if(result == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, request.Id);
            }

            return result;
        }
    }
}
