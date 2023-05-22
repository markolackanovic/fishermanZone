using Application.Common.Mappings;

namespace Application.BusinessLogic.TipDatoteke.Queries.GetTipDatotekeById
{
    public class TipDatotekeViewModel : IMapFrom<Domain.Entities.TipDatoteke>
    {
        public int TipDatotekeID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
