using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;

public class CreateTipAdministrativneJediniceCommandHandler : CreateCommandHandler<CreateTipAdministrativneJediniceCommand,Domain.Entities.TipAdministrativneJedinice>
{
    public CreateTipAdministrativneJediniceCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
