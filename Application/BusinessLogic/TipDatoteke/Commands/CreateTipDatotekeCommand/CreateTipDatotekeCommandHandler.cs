using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;

namespace Application.BusinessLogic.TipDatoteke.Commands.CreateTipDatotekeCommand;

public class CreateTipDatotekeCommandHandler : CreateCommandHandler<CreateTipDatotekeCommand, Domain.Entities.TipDatoteke>
{
    public CreateTipDatotekeCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
