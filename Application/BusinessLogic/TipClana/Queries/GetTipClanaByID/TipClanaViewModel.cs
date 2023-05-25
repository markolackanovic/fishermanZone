using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.GetTipClana.Queries.GetTipClanaByID
{
    public class TipClanaViewModel : IMapFrom<Domain.Entities.TipClana>
    {
        public int TipClanaId { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
