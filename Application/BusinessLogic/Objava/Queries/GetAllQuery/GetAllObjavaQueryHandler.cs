using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetAll;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Objava.Queries.GetAllQuery
{
    public class GetAllObjavaQueryHandler : GetAllQueryHandler<GetAllObjavaViewModel, GetAllObjavaQuery, Domain.Entities.Objava>
    {
        public GetAllObjavaQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
