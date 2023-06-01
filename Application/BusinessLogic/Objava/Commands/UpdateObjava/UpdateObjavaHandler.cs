using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Objava.Commands.UpdateObjava
{
    public class UpdateObjavaHandler : UpdateCommandHandler<UpdateObjavaCommand, Domain.Entities.Objava>
    {
        public UpdateObjavaHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
