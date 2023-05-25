using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Queries.SearchTipDatoteke
{
    public class SearchTipDatotekeViewModel : IMapFrom<Domain.Entities.TipDatoteke>
    {
        public int TipDatotekeID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
