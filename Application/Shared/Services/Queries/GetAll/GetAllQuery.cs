using Application.Common.Models.Respones;
using Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Queries.GetAll
{
    public class GetAllQuery<TViewModel> : PagedResponseQuery, IRequest<PagedResponse<TViewModel>>
        where TViewModel : class
    {
    }
}
