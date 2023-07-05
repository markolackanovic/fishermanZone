using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;

namespace Application.BusinessLogic.Korisnik.Commands.Create
{
    public class CreateKorisnikCommandHandler : CreateCommandHandler<CreateKorisnikCommand, Domain.Entities.Korisnik>
    {
        public CreateKorisnikCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
