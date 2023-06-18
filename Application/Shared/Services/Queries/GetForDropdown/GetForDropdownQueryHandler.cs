using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Common.Models.Respones;
using Application.Shared.Services.Queries.GetAll;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Queries.GetForDropdown
{
    public class GetForDropdownQueryHandler<TViewModel, TQuery, TEntity> : IRequestHandler<TQuery, IList<TViewModel>>
         where TViewModel : class
         where TQuery : GetForDropdownQuery<TViewModel>
         where TEntity : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetForDropdownQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<IList<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>()
                .Where(ExpressionHelper.ActiveExpression<TEntity>())
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        }
    }
}
