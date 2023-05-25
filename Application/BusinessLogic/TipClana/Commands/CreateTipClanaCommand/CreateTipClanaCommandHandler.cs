using Application.Shared.Services.Create;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BusinessLogic.TipClana.Commands.CreateTipClanaCommand;

public class CreateTipClanaCommandHandler : CreateCommandHandler<CreateTipClanaCommand,Domain.Entities.TipClana>
{
    public CreateTipClanaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
