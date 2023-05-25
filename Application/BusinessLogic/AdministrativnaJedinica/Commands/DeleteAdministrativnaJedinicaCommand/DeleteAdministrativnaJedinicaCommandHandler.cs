using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand
{
    public class DeleteAdministrativnaJedinicaCommandHandler : DeleteCommandHandler<DeleteAdministrativnaJedinicaCommand, Domain.Entities.AdministrativnaJedinica>
    {
        public DeleteAdministrativnaJedinicaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }
    }
}
