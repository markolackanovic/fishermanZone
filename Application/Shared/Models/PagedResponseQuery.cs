using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Models
{
    public class PagedResponseQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
