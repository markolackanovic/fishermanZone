using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Shared.Delete
{
    public class DeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
