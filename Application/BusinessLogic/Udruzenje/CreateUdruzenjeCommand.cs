using Application.BusinessLogic.Shared.Create;
using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class CreateUdruzenjeCommand : CreateCommand, IMapFrom<Domain.Entities.Udruzenje>
    {
        public int NadredjenoUdruzenjeID { get; set; }
        public string Naziv { get; set; }
        public int AdministrativnaJedinicaID { get; set; }
        public string Adresa { get; set; }
        public string Opis { get; set; }
        public string LogoPath { get; set; }
    }
}
