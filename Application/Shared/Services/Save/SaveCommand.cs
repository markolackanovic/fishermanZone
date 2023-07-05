using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services.Save
{
    public class SaveCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public bool Aktivno { get; set; } = true;
    }

}
