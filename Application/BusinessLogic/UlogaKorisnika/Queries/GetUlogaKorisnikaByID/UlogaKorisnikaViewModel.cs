using Application.BusinessLogic.Shared.Queries.GetByID;
using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.UlogaKorisnika.Queries.GetUlogaKorisnikaByID
{
    public class UlogaKorisnikaViewModel : IMapFrom<Domain.Entities.UlogaKorisnika>
    {
        public int UlogaKorisnikaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool Aktivno { get; set; }
    }
}
