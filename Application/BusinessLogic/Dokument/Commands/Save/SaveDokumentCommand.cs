using Application.Common.Mappings;
using Application.Shared.Services.Save;

namespace Application.BusinessLogic.Dokument.Commands.Save
{
    public class SaveDokumentCommand : SaveCommand, IMapFrom<Domain.Entities.Dokument>
    {
        public int DokumentId { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; } = null!;
        public int UdruzenjeId { get; set; }
        public int DatotekaId { get; set; }
        public string NazivDatoteke { get; set; } = null!;
        public string? EkstenzijaDatoteke { get; set; } = null!;
        public string? Base64Datoteke { get; set; } = null!;
    }
}
