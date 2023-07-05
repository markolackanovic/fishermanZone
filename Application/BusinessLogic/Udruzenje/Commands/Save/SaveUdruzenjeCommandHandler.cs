using Application.Common.Interfaces;
using Application.Shared.Services.Save;
using AutoMapper;

namespace Application.BusinessLogic.Udruzenje.Commands.Save
{
    public class SaveUdruzenjeCommandHandler : SaveCommandHandler<SaveUdruzenjeCommand, Domain.Entities.Udruzenje>
    {
        public SaveUdruzenjeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}