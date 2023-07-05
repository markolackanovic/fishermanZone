using Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.BusinessLogic.Dokument.Queries
{
    public class DokumentViewModel : IMapFrom<Domain.Entities.Dokument>
    {
        public int Id { get; set; }
        public int DokumentId { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; } = null!;
        public int UdruzenjeId { get; set; }
        public int DatotekaId { get; set; }
        public string NazivDatoteke { get; set; } = null!;
        public string Base64Datoteke { get; set; } = null!;
        public string GuidDatoteke { get; set; } = null!;
        public string EkstenzijaDatoteke { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Dokument, DokumentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DokumentId))
               .ForMember(dest => dest.NazivDatoteke, opt => opt.MapFrom(src => src.Datoteka.Naziv))
               .ForMember(dest => dest.GuidDatoteke, opt => opt.MapFrom(src => src.Datoteka.Guid))
               .ForMember(dest => dest.EkstenzijaDatoteke, opt => opt.MapFrom(src => src.Datoteka.Ekstenzija))
            ;
        }
    }
}
