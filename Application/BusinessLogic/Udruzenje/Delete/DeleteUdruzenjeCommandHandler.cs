using Application.BusinessLogic.Shared.Delete;
using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Delete
{
    public class DeleteUdruzenjeCommandHandler : DeleteCommandHandler<DeleteUdruzenjeCommand, Domain.Entities.Udruzenje>
    {
        public DeleteUdruzenjeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
