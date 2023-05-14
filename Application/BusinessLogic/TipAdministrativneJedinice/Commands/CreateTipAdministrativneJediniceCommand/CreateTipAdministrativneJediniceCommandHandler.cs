using Application.BusinessLogic.Shared;
using Application.BusinessLogic.Shared.Create;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;

public class CreateTipAdministrativneJediniceCommandHandler : CreateCommandHandler<CreateTipAdministrativneJediniceCommand,Domain.Entities.TipAdministrativneJedinice>
{
    public CreateTipAdministrativneJediniceCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
