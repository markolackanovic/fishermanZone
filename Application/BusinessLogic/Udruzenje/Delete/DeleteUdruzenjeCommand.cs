using Application.BusinessLogic.Shared.Delete;
using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Delete
{
    public class DeleteUdruzenjeCommand : DeleteCommand,IMapFrom<Domain.Entities.Udruzenje>
    { 
    }
}
