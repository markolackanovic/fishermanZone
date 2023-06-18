using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Queries.GetForDropdown
{
    public class UdruzenjeDropdownViewModel : IMapFrom<Domain.Entities.Udruzenje>
    {
        public int UdruzenjeId { get; set; }
        public string? Naziv { get; set; }
    }
}
