using Application.BusinessLogic.Shared.Update;
using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
