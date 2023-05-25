using Application.Common.Mappings;
using Application.Shared.Services.Delete;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.DeleteAdministrativnaJedinicaCommand;

public class DeleteAdministrativnaJedinicaCommand : DeleteCommand, IMapFrom<Domain.Entities.AdministrativnaJedinica>
{

}
