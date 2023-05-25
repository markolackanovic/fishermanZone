using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Queries
{
    public class GetAdministrativnaJedinicaByIdQueryHandler : GetByIdQueryHandler<AdministrativnaJedinicaViewModel, GetAdministrativnaJedinicaByIdQuery, Domain.Entities.AdministrativnaJedinica>
    {
        public GetAdministrativnaJedinicaByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
