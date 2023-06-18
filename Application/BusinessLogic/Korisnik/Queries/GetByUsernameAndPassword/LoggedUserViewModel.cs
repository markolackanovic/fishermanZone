using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetById;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword
{
    public class LoggedUserViewModel : IMapFrom<Domain.Entities.Korisnik>
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
        public int? UdruzenjeId { get; set; }
        public int UlogaKorisnikaId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}

