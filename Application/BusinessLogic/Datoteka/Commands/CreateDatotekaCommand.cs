using Application.Common.Mappings;
using Application.Shared.Services.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Datoteka.Commands
{
    public class CreateDatotekaCommand : CreateCommand, IMapFrom<Domain.Entities.Datoteka>
    {
        public int DatotekaId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public int TipDatotekeId { get; set; }
        public Guid GuidDatoteke { get; set; }
        public string Ekstenzija { get; set; } = string.Empty;
        public string Base64Logo { get; set; } = string.Empty;
    }
}