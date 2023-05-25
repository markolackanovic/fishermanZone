﻿using Application.Common.Mappings;
using AutoMapper;

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
