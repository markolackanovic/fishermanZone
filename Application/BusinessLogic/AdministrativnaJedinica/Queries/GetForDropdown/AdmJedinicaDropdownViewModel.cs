using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Queries.GetForDropdown
{
    public class AdmJedinicaDropdownViewModel : IMapFrom<Domain.Entities.AdministrativnaJedinica>
    {
        public int AdministrativnaJedinicaId { get; set; }
        public string? Naziv { get; set; }
    }
}
