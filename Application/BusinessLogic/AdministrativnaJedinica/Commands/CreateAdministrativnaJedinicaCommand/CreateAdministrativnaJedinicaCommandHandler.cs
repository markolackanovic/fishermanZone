using Application.BusinessLogic.Shared;
using Application.BusinessLogic.Shared.Create;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand
{
    public class CreateAdministrativnaJedinicaCommandHandler : CreateCommandHandler<CreateAdministrativnaJedinicaCommand, Domain.Entities.AdministrativnaJedinica>
    {
        public CreateAdministrativnaJedinicaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }
    }
}
