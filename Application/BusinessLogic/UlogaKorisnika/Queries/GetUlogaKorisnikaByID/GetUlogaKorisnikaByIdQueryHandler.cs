using Application.Common.Interfaces;
using Application.Shared.Services.Queries.GetByID;
using AutoMapper;

namespace Application.BusinessLogic.UlogaKorisnika.Queries.GetUlogaKorisnikaByID
{
    public class UlogaKorisnikaByIdQueryHandler : GetByIdQueryHandler<UlogaKorisnikaViewModel, GetUlogaKorisnikaByIdQuery, Domain.Entities.UlogaKorisnika>
    {
        public UlogaKorisnikaByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
