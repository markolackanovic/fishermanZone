using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.BusinessLogic.Dokument.Commands.Delete
{
    public class DeleteDokumentCommandHandler : DeleteCommandHandler<DeleteDokumentCommand, Domain.Entities.Dokument>
    {
        IApplicationDbContext _context;
        public DeleteDokumentCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<int> Handle(DeleteDokumentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Dokument dokument = _context.Set<Domain.Entities.Dokument>().Find(request.Id);
            Domain.Entities.Datoteka datoteka = _context.Set<Domain.Entities.Datoteka>().Find(dokument.DatotekaId);
            try
            {
                dokument.GetType().GetProperty("Aktivno").SetValue(dokument, false);
                datoteka.GetType().GetProperty("Aktivno").SetValue(datoteka, false);
            }
            catch (Exception e)
            {
                throw e;
            }
            // postaiti vrijednost atribut active na false
            _context.Set<Domain.Entities.Dokument>().Update(dokument);
            _context.Set<Domain.Entities.Datoteka>().Update(datoteka);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return (int)dokument.DokumentId;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}