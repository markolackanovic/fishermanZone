using Application.BusinessLogic.Udruzenje.Commands.Create;
using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Korisnik.Commands.Create
{
    public class CreateKorisnikCommandHandler : CreateCommandHandler<CreateKorisnikCommand, Domain.Entities.Korisnik>
    {
        public CreateKorisnikCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
