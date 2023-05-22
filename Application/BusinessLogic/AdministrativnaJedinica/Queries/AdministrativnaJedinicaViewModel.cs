using Application.BusinessLogic.Shared.Queries.GetByID;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.AdministrativnaJedinica.Queries
{
    public class AdministrativnaJedinicaViewModel : IMapFrom<Domain.Entities.AdministrativnaJedinica>
    {
        public int AdministrativnaJedinicaId { get; set; }
        public string Naziv { get; set; }
        public string TipAdministrativneJedinice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.AdministrativnaJedinica, AdministrativnaJedinicaViewModel>()
               .ForMember(dest => dest.TipAdministrativneJedinice, opt => opt.MapFrom(src => src.TipAdministrativneJedinice.Naziv));
        } 
    }
}
