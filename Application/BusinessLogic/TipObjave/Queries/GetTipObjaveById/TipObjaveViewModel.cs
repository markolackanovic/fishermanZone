using Application.Common.Mappings;

namespace Application.BusinessLogic.TipObjave.Queries.GetTipObjaveById
{
    public class TipObjaveViewModel : IMapFrom<Domain.Entities.TipObjave>
    {
        public int TipObjaveID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
