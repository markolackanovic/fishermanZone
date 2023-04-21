using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class BasePaginationModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Column { get; set; }
        public bool IsDesc { get; set; }
    }
}
