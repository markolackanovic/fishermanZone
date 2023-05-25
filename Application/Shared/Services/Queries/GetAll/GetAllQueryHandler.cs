using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models.Respones;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Queries.GetAll
{
    public class GetAllQueryHandler<TViewModel, TQuery, TEntity> : IRequestHandler<TQuery, PagedResponse<TViewModel>>
        where TViewModel : class
        where TQuery : GetAllQuery<TViewModel>
        where TEntity : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>()
                .Where(ExpressionHelper.ActiveExpression<TEntity>())
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

        }
    }
}
