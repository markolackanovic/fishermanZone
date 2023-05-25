using Application.BusinessLogic.Shared.Update;
using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.UpdateUlogaKorisnikaCommand
{
    public class UpdateUlogaKorisnikaHandler : UpdateCommandHandler<UpdateUlogaKorisnikaCommand, Domain.Entities.UlogaKorisnika>
    {
        public UpdateUlogaKorisnikaHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
