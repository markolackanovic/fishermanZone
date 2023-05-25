using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Commands.DeleteTipDatotekeCommand
{
    public class DeleteTipDatotekeCommandHandler : DeleteCommandHandler<DeleteTipDatotekeCommand, Domain.Entities.TipDatoteke>
    {
        public DeleteTipDatotekeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
