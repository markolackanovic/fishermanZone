using Application.Common.Infrastructure.Extensions;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models.Respones;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.SearchTipAdministrativneJedinice
{
    public class SearchTipAdministrativneJediniceQueryHandler : IRequestHandler<SearchTipAdministrativneJediniceQuery, PagedResponse<SearchTipAdministrativneJediniceViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SearchTipAdministrativneJediniceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<SearchTipAdministrativneJediniceViewModel>> Handle(SearchTipAdministrativneJediniceQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Set<Domain.Entities.TipAdministrativneJedinice>()
                           .WhereIf(!string.IsNullOrEmpty(request.Naziv), c => c.Naziv.ToLower().Contains(request.Naziv.ToLower()))
                           .ProjectTo<SearchTipAdministrativneJediniceViewModel>(_mapper.ConfigurationProvider)
                           .PaginatedListAsync(1,5);
            
            return result;
        }
    }
}
