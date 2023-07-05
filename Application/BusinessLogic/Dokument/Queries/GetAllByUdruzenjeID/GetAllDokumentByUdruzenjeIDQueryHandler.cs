using Application.Authentification;
using Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword;
using Application.Common.Interfaces;
using Application.Common.Security;
using Application.Shared.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Dokument.Queries.GetAllByUdruzenjeID
{
    public class GetAllDokumentByUdruzenjeIDQueryHandler : IRequestHandler<GetAllDokumentByUdruzenjeIDQuery, List<DokumentViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllDokumentByUdruzenjeIDQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DokumentViewModel>> Handle(GetAllDokumentByUdruzenjeIDQuery request, CancellationToken cancellationToken)
        {
            var documents = await _context.Set<Domain.Entities.Dokument>()
                .Where(u => u.UdruzenjeId == request.UdruzenjeId && u.Aktivno)
                .ProjectTo<DokumentViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return documents;
        }
    }
}

