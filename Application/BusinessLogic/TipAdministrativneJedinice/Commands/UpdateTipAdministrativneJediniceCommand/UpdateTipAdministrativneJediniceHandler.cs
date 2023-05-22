using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Commands.UpdateTipAdministrativneJediniceCommand
{
    public class UpdateTipAdministrativneJediniceHandler : UpdateCommandHandler<UpdateTipAdministrativneJediniceCommand, Domain.Entities.TipAdministrativneJedinice>
    {
        public UpdateTipAdministrativneJediniceHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
