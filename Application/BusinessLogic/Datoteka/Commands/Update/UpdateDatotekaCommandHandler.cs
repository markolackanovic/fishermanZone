using Application.BusinessLogic.Datoteka.Commands.Create;
using Application.BusinessLogic.Objava.Commands.UpdateObjava;
using Application.Common.Interfaces;
using Application.Shared.Services.Update;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Datoteka.Commands.Update
{
    public class UpdateDatotekaCommandHandler : UpdateCommandHandler<UpdateDatotekaCommand, Domain.Entities.Datoteka>
    {
        public UpdateDatotekaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

