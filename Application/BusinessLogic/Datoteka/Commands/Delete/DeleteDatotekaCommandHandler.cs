using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Datoteka.Commands.Delete
{
    public class DeleteDatotekaCommandHandler : DeleteCommandHandler<DeleteDatotekaCommand, Domain.Entities.Datoteka>
    {
        public DeleteDatotekaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
