using Application.Common.Models.Respones;
using Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Queries.SearchTipAdministrativneJedinice
{
    public class SearchTipAdministrativneJediniceQuery : PagedResponseQuery, IRequest<PagedResponse<SearchTipAdministrativneJediniceViewModel>>
    {
        public int TipAdministrativneJediniceID { get; set; }
        public string Naziv { get; set; }
    }
}
