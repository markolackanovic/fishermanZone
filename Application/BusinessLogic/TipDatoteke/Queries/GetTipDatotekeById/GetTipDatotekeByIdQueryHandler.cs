using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Queries.GetTipDatotekeById
{
    public class GetTipDatotekeByIdQueryHandler : GetByIdQueryHandler<TipDatotekeViewModel, GetTipDatotekeByIdQuery, Domain.Entities.TipDatoteke>
    {
        public GetTipDatotekeByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
