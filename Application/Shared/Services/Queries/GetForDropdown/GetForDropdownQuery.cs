using Application.Common.Models.Respones;
using Application.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Queries.GetForDropdown
{
    public class GetForDropdownQuery<TViewModel> : IRequest<IList<TViewModel>>
        where TViewModel : class
    {
        public int Id { get; set; }
    }
}
