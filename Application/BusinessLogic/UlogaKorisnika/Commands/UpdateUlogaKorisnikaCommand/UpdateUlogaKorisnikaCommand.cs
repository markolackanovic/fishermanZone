using Application.Common.Mappings;
using Application.Shared.Services.Update;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.UpdateUlogaKorisnikaCommand
{
    public class UpdateUlogaKorisnikaCommand : UpdateCommand , IMapFrom<Domain.Entities.UlogaKorisnika>
    {
        public int UlogaKorisnikaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool Aktivno { get; set; }
    }
}
