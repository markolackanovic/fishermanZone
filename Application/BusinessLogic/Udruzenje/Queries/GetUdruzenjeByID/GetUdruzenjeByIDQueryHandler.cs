using Application.BusinessLogic.GetTipClana.Queries.GetTipClanaByID;
using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID
{
    public class GetUdruzenjeByIDQueryHandler : GetByIdQueryHandler<UdruzenjeViewModel, GetUdruzenjeByIDQuery, Domain.Entities.Udruzenje>
    {
        public GetUdruzenjeByIDQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
