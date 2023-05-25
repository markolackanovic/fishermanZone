using Application.Common.Mappings;
using Application.Shared.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipObjave.Commands.UpdateTipObjaveCommand
{
    public class UpdateTipObjaveCommand : UpdateCommand , IMapFrom<Domain.Entities.TipObjave>
    {
        public int TipObjaveID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
