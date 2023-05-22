using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetTipAdministrativneJediniceById
{
    public class GetTipAdministrativneJediniceByIdQueryHandler : GetByIdQueryHandler<TipAdministrativneJediniceViewModel, GetTipAdministrativneJediniceByIdQuery, Domain.Entities.TipAdministrativneJedinice>
    {
        public GetTipAdministrativneJediniceByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
