using Application.Common.Mappings;
using AutoMapper;

namespace Application.BusinessLogic.AdministrativnaJedinica.Queries.GetById
{
    public class AdministrativnaJedinicaViewModel : IMapFrom<Domain.Entities.AdministrativnaJedinica>
    {
        public int AdministrativnaJedinicaId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string TipAdministrativneJedinice { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.AdministrativnaJedinica, AdministrativnaJedinicaViewModel>()
               .ForMember(dest => dest.TipAdministrativneJedinice, opt => opt.MapFrom(src => src.TipAdministrativneJedinice.Naziv));
        }
    }
}
