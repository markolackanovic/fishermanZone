using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.DeleteUlogaKorisnikaCommand
{
    public class DeleteUlogaKorisnikaCommandHandler : DeleteCommandHandler<DeleteUlogaKorisnikaCommand, Domain.Entities.UlogaKorisnika>
    {
        public DeleteUlogaKorisnikaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
