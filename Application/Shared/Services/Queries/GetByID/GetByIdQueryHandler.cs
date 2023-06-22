using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Shared.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Services.Queries.GetByID
{
    public class GetByIdQueryHandler<TViewModel, TQuery, TEntity> : IRequestHandler<TQuery, ServiceResult<TViewModel>>
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

        public virtual async Task<ServiceResult<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .SingleOrDefault();
            if (keyName == null)
            {
                return new ServiceResult<TViewModel> {
                    IsError = true,
                    ErrorMessage = "Primary key cannot be null!"
                };
            }

            var result = await _context.Set<TEntity>()
                .Where(ExpressionHelper.CreateExpression<TEntity>(keyName, request.Id))
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            if(result == null)
            {
                return new ServiceResult<TViewModel>
                {
                    IsError = true,
                    ErrorMessage = "Entity not found!"
                };
            }

            return new ServiceResult<TViewModel>
            {
                IsError = false,
                Result = result
            };
        }
    }
}
