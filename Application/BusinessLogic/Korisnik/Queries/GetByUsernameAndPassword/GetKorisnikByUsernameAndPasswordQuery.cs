using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Korisnik.Queries.GetByUsernameAndPassword
{
    public class GetKorisnikByUsernameAndPasswordQuery : IRequest<LoggedUserViewModel>
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}