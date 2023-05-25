using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipObjave.Commands.UpdateTipObjaveCommand
{
    public class UpdateTipObjaveCommandHandler : UpdateCommandHandler<UpdateTipObjaveCommand, Domain.Entities.TipObjave>
    {
        public UpdateTipObjaveCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
