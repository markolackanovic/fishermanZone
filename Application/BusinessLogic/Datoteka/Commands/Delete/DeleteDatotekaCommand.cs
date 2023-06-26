using Application.Common.Mappings;
using Application.Shared.Services.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Datoteka.Commands.Delete
{
    public class DeleteDatotekaCommand : DeleteCommand, IMapFrom<Domain.Entities.Datoteka>
    {
    }
}
