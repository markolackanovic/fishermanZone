using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.GetObjava.Queries.GetObjavaByID
{
    public class ObjavaViewModel : IMapFrom<Domain.Entities.Objava>
    {
        public int ObjavaId { get; set; }
        public string? Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateOnly? DatumObjave { get; set; }
        public string LokacijaLat { get; set; }
        public string LokacijaLong { get; set; }
        public int TipObjaveId { get; set; }
        public bool Aktivno { get; set; }
    }
}
