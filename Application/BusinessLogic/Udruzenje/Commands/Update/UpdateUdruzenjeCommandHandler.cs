using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Commands.Update
{
    public class UpdateUdruzenjeCommandHandler : UpdateCommandHandler<UpdateUdruzenjeCommand, Domain.Entities.Udruzenje>
    {
        public UpdateUdruzenjeCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
