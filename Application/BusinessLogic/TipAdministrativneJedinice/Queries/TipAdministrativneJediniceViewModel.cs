using Application.BusinessLogic.Shared.Queries.GetByID;
using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries
{
    public class TipAdministrativneJediniceViewModel : IMapFrom<Domain.Entities.TipAdministrativneJedinice>
    {
        public int TipAdministrativneJediniceId { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
