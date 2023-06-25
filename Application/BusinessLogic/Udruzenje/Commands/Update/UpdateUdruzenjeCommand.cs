using Application.Common.Mappings;
using Application.Shared.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Commands.Update
{
    public class UpdateUdruzenjeCommand : UpdateCommand, IMapFrom<Domain.Entities.Udruzenje>
    {
        public int UdruzenjeId { get; set; }
        public int NadredjenoUdruzenjeID { get; set; }
        public string Naziv { get; set; }
        public int AdministrativnaJedinicaID { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string? KontaktEmail { get; set; }
        public string Opis { get; set; }
        public string? Base64Logo { get; set; }
        public string? NazivLogoDatoteke { get; set; }
        public int LogoDatotekaId { get; set; }
    }
}