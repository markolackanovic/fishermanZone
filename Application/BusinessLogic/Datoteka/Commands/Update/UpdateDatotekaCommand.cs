using Application.Common.Mappings;
using Application.Shared.Services.Create;
using Application.Shared.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Datoteka.Commands.Update
{
    public class UpdateDatotekaCommand : UpdateCommand, IMapFrom<Domain.Entities.Datoteka>
    {
        public int DatotekaId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Ekstenzija { get; set; } = string.Empty;
        public string Guid { get; set; } = string.Empty;    
        public int TipDatotekeId { get; set; }
    }
}
