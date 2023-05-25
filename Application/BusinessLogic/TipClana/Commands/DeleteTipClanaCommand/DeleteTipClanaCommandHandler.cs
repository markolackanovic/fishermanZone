using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;

namespace Application.BusinessLogic.TipClana.Commands.DeleteTipClanaCommand
{
    public class DeleteTipClanaCommandHandler : DeleteCommandHandler<DeleteTipClanaCommand, Domain.Entities.TipClana>
    {
        public DeleteTipClanaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
