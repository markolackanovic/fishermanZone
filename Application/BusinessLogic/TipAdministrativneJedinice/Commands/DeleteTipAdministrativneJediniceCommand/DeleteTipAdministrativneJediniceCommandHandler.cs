using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Commands.DeleteTipAdministrativneJediniceCommand
{
    public class DeleteTipAdministrativneJediniceCommandHandler : DeleteCommandHandler<DeleteTipAdministrativneJediniceCommand, Domain.Entities.TipAdministrativneJedinice>
    {
        public DeleteTipAdministrativneJediniceCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
