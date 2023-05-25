using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;

namespace Application.BusinessLogic.TipObjave.Commands.DeleteTipObjaveCommand
{
    public class DeleteTipObjaveCommandHandler : DeleteCommandHandler<DeleteTipObjaveCommand, Domain.Entities.TipObjave>
    {
        public DeleteTipObjaveCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
