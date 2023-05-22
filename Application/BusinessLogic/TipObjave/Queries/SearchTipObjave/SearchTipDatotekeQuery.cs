using Application.Common.Models.Respones;
using Application.Shared.Models;
using MediatR;

namespace Application.BusinessLogic.TipObjave.Queries.SearchTipObjave
{
    public class SearchTipObjaveQuery : PagedResponseQuery,IRequest<PagedResponse<SearchTipObjaveViewModel>>
    {
        public int TipObjaveID { get; set; }
        public string Naziv { get; set; }
    }
}
