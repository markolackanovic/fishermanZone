using Application.BusinessLogic.Shared.Create;
using Application.BusinessLogic.Shared.Delete;
using Application.Common.Mappings;
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
