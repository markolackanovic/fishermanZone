using Application.BusinessLogic.Shared.Delete;
using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipClana.Commands.DeleteTipClanaCommand
{
    public class DeleteTipClanaCommandHandler : DeleteCommandHandler<DeleteTipClanaCommand, Domain.Entities.TipClana>
    {
        public DeleteTipClanaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
