using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.BusinessLogic.Datoteka.Commands.Create
{
    public class CreateDatotekaCommandHandler : CreateCommandHandler<CreateDatotekaCommand, Domain.Entities.Datoteka>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDatotekaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}

