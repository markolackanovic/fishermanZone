using MediatR;

namespace Application.BusinessLogic.Dokument.Queries.GetAllByUdruzenjeID
{
    public class GetAllDokumentByUdruzenjeIDQuery : IRequest<List<DokumentViewModel>>
    {
        public int UdruzenjeId { get; set; }
    }
}
