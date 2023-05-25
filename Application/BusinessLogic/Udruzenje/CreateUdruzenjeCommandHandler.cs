using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class CreateUdruzenjeCommandHandler : CreateCommandHandler<CreateUdruzenjeCommand, Domain.Entities.Udruzenje>
    {
        public CreateUdruzenjeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
