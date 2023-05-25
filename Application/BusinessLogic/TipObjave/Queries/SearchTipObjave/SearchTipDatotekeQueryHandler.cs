using Application.Common.Infrastructure.Extensions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models.Respones;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.BusinessLogic.TipObjave.Queries.SearchTipObjave
{
    public class SearchTipObjaveQueryHandler : IRequestHandler<SearchTipObjaveQuery, PagedResponse<SearchTipObjaveViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SearchTipObjaveQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<SearchTipObjaveViewModel>> Handle(SearchTipObjaveQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Set<Domain.Entities.TipObjave>()
                           .WhereIf(!string.IsNullOrEmpty(request.Naziv), c => c.Naziv.ToLower().Contains(request.Naziv.ToLower()))
                           .ProjectTo<SearchTipObjaveViewModel>(_mapper.ConfigurationProvider)
                           .PaginatedListAsync(request.PageNumber,request.PageSize);
            
            return result;
        }
    }
}
