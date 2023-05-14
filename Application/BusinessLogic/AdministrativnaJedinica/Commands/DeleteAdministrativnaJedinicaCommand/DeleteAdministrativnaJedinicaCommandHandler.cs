using Application.BusinessLogic.Shared;
using Application.BusinessLogic.Shared.Create;
using Application.BusinessLogic.Shared.Delete;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand
{
    public class DeleteAdministrativnaJedinicaCommandHandler : DeleteCommandHandler<DeleteAdministrativnaJedinicaCommand, Domain.Entities.AdministrativnaJedinica>
    {
        public DeleteAdministrativnaJedinicaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }
    }
}
