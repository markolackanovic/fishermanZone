using Application.Common.Models.Respones;
using Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Queries.SearchTipDatoteke
{
    public class SearchTipDatotekeQuery : PagedResponseQuery,IRequest<PagedResponse<SearchTipDatotekeViewModel>>
    {
        public int TipDatotekeID { get; set; }
        public string Naziv { get; set; }
    }
}
