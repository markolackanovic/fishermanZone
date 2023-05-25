using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;

namespace Application.BusinessLogic.GetTipClana.Queries.GetTipClanaByID
{
    public class GetTipClanaByIdQueryHandler : GetByIdQueryHandler<TipClanaViewModel, GetTipClanaByIdQuery, Domain.Entities.TipClana>
    {
        public GetTipClanaByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
