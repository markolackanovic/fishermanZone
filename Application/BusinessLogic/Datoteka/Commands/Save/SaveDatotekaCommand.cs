using Application.Common.Mappings;
using Application.Shared.Services.Save;

namespace Application.BusinessLogic.Datoteka.Commands.Save
{
    public class SaveDatotekaCommand : SaveCommand, IMapFrom<Domain.Entities.Datoteka>
    {
        public int DatotekaId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Guid { get; set; } = string.Empty;
        public string Ekstenzija { get; set; } = string.Empty;
        public int TipDatotekeId { get; set; }
    }
}
