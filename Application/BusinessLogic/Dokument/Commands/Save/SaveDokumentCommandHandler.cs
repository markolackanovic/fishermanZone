using Application.Common.Interfaces;
using Application.Shared.Services.Save;
using AutoMapper;

namespace Application.BusinessLogic.Dokument.Commands.Save
{
    public class SaveDokumentCommandHandler : SaveCommandHandler<SaveDokumentCommand, Domain.Entities.Dokument>
    {
        public SaveDokumentCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
           
        }
    }
}

