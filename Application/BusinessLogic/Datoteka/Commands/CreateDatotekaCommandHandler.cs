using Application.Common.Interfaces;
using Application.Shared.Services.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.BusinessLogic.Datoteka.Commands
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

        public override async Task<int> Handle(CreateDatotekaCommand request, CancellationToken cancellationToken)
        {
            string fileName = request.GuidDatoteke.ToString() + "." + request.Ekstenzija;
            var path = Path.Combine(@"C:\Users\pero.novakovic\test", fileName);
            
            File.WriteAllBytes(path, Convert.FromBase64String(request.Base64Logo));

            request.Naziv = fileName;
            request.TipDatotekeId = _context.Set<Domain.Entities.TipDatoteke>().FirstOrDefault(x => x.Ekstenzija == request.Ekstenzija).TipDatotekeId;

            var entity = _mapper.Map<CreateDatotekaCommand, Domain.Entities.Datoteka>(request);
            _context.Set<Domain.Entities.Datoteka>().Add(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return entity.DatotekaId;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

