using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;

namespace Application.BusinessLogic.GetObjava.Queries.GetObjavaByID
{
    public class GetObjavaByIdQueryHandler : GetByIdQueryHandler<ObjavaViewModel, GetObjavaByIdQuery, Domain.Entities.Objava>
    {
        public GetObjavaByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
