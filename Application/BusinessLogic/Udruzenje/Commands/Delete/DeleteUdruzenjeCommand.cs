using Application.Common.Mappings;
using Application.Shared.Services.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Commands.Delete
{
    public class DeleteUdruzenjeCommand : DeleteCommand, IMapFrom<Domain.Entities.Udruzenje>
    {
    }
}
