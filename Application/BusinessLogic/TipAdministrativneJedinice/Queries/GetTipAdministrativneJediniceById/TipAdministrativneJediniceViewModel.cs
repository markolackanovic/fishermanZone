using Application.Common.Mappings;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetTipAdministrativneJediniceById
{
    public class TipAdministrativneJediniceViewModel : IMapFrom<Domain.Entities.TipAdministrativneJedinice>
    {
        public int TipAdministrativneJediniceId { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
