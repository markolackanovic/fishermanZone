using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand
{
    public class CreateAdministrativnaJedinicaCommandHandler : CreateCommandHandler<CreateAdministrativnaJedinicaCommand, Domain.Entities.AdministrativnaJedinica>
    {
        public CreateAdministrativnaJedinicaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }
    }
}
