using Application.BusinessLogic.Shared.Update;
using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipClana.Commands.UpdateTipClanaCommand
{
    public class UpdateTipClanaHandler : UpdateCommandHandler<UpdateTipClanaCommand, Domain.Entities.TipClana>
    {
        public UpdateTipClanaHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
