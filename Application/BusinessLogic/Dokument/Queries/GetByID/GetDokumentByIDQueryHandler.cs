using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Dokument.Queries.GetByID
{
    public class GetDokumentByIDQueryHandler : GetByIdQueryHandler<DokumentViewModel, GetDokumentByIDQuery, Domain.Entities.Dokument>
    {
        public GetDokumentByIDQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
