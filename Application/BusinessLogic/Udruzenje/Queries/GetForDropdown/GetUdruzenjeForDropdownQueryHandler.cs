using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.Common.Helpers;
using Application.Common.Infrastructure.Extensions;
using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetForDropdown;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Queries.GetForDropdown
{
    public class GetUdruzenjeForDropdownQueryHandler : GetForDropdownQueryHandler<UdruzenjeDropdownViewModel, GetUdruzenjeForDropdownQuery, Domain.Entities.Udruzenje>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUdruzenjeForDropdownQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public override async Task<IList<UdruzenjeDropdownViewModel>> Handle(GetUdruzenjeForDropdownQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Set<Domain.Entities.Udruzenje>()
                .Where(x=> x.Aktivno && (request.NadredjenoUdruzenjeId == 0 || x.NadredjenoUdruzenjeId == request.NadredjenoUdruzenjeId))
                .ProjectTo<UdruzenjeDropdownViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;

        }
    }
}
