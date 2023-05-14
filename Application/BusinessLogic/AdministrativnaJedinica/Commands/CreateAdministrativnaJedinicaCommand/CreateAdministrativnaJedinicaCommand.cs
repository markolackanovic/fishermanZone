using Application.BusinessLogic.Shared.Create;
using Application.Common.Mappings;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Commands.CreateAdministrativnaJedinicaCommand;

public class CreateAdministrativnaJedinicaCommand : CreateCommand,IMapFrom<Domain.Entities.AdministrativnaJedinica>
{
    public string Naziv { get; set; }
    public int TipAdministrativneJediniceID { get; set; }
}
