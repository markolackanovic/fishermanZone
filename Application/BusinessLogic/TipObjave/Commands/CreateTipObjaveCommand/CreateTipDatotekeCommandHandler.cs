using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;

namespace Application.BusinessLogic.TipObjave.Commands.CreateTipObjaveCommand;

public class CreateTipObjaveCommandHandler : CreateCommandHandler<CreateTipObjaveCommand, Domain.Entities.TipObjave>
{
    public CreateTipObjaveCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
