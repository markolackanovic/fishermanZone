using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown;
using Application.Shared.Services.Queries.GetForDropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Queries.GetForDropdown
{
    public class GetUdruzenjeForDropdownQuery : GetForDropdownQuery<UdruzenjeDropdownViewModel>
    {
        public int NadredjenoUdruzenjeId { get; set; }
    }
}
