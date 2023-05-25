using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetAll;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetAllQuery
{
    public class GetAllTipAdministrativneJediniceQueryHandler : GetAllQueryHandler<GetAllTipAdministrativneJediniceViewModel, GetAllTipAdministrativneJediniceQuery, Domain.Entities.TipAdministrativneJedinice>
    {
        public GetAllTipAdministrativneJediniceQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
