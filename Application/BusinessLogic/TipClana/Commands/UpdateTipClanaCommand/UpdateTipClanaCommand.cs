using Application.BusinessLogic.Shared.Update;
using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipClana.Commands.UpdateTipClanaCommand
{
    public class UpdateTipClanaCommand : UpdateCommand , IMapFrom<Domain.Entities.TipClana>
    {
        public int TipClanaID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
