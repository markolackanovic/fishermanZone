﻿using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.GetAllQuery
{
    public class GetAllTipAdministrativneJediniceViewModel : IMapFrom<Domain.Entities.TipAdministrativneJedinice>
    {
        public int TipAdministrativneJediniceID { get; set; }
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}
