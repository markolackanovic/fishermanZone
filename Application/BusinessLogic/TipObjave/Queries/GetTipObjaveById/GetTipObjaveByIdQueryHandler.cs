using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;

namespace Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById
{
    public class GetTipObjaveByIdQueryHandler : GetByIdQueryHandler<TipObjaveViewModel, GetTipObjaveByIdQuery, Domain.Entities.TipObjave>
    {
        public GetTipObjaveByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
