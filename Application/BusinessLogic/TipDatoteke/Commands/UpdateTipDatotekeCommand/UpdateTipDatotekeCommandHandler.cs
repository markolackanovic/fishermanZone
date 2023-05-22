using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipDatoteke.Commands.UpdateTipDatotekeCommand
{
    public class UpdateTipDatotekeCommandHandler : UpdateCommandHandler<UpdateTipDatotekeCommand, Domain.Entities.TipDatoteke>
    {
        public UpdateTipDatotekeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
