using Application.Common.Interfaces;
using Application.Shared.Services.Save;
using AutoMapper;

namespace Application.BusinessLogic.Datoteka.Commands.Save
{
    public class SaveDatotekaCommandHandler : SaveCommandHandler<SaveDatotekaCommand, Domain.Entities.Datoteka>
    {
        public SaveDatotekaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
