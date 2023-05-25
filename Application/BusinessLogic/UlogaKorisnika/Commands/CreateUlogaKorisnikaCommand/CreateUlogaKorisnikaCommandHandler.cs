using Application.BusinessLogic.Shared;
using Application.BusinessLogic.Shared.Create;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.CreateUlogaKorisnikaCommand;

public class CreateUlogaKorisnikaCommandHandler : CreateCommandHandler<CreateUlogaKorisnikaCommand,Domain.Entities.UlogaKorisnika>
{
    public CreateUlogaKorisnikaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
