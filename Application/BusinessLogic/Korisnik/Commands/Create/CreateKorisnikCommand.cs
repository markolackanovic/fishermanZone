using Application.Common.Mappings;
using Application.Shared.Services.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Korisnik.Commands.Create
{
    public class CreateKorisnikCommand : CreateCommand, IMapFrom<Domain.Entities.Korisnik>
    {
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;

        public string? KorisnickoIme { get; set; } = string.Empty;

        public string Lozinka { get; set; } = string.Empty;

        public int? UdruzenjeId { get; set; }

        public int? UlogaKorisnikaId { get; set; }

        public string? ProfilnaSlika { get; set; }
    }
}
