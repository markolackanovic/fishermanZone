using Application.Common.Mappings;
using Application.Shared.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Commands.UpdateTipDatotekeCommand
{
    public class UpdateTipDatotekeCommand : UpdateCommand , IMapFrom<Domain.Entities.TipDatoteke>
    {
        public int TipDatotekeID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
