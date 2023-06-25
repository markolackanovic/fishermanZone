using Application.BusinessLogic.AdministrativnaJedinica.Queries.GetById;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Udruzenje.Queries.GetUdruzenjeByID
{
    public class UdruzenjeViewModel : IMapFrom<Domain.Entities.Udruzenje>
    {
        public int UdruzenjeId { get; set; }
        public int? NadredjenoUdruzenjeId { get; set; }
        public string RibolovackiSavez { get; set; } = string.Empty;
        public string Naziv { get; set; } = null!;
        public int AdministrativnaJedinicaId { get; set; }
        public string Mjesto { get; set; } = null!;
        public string? Adresa { get; set; }
        public string? Opis { get; set; }
        public string KontaktTelefon { get; set; } = string.Empty;
        public string KontaktEmail { get; set; } = string.Empty;
        public int UkupnoClanova { get; set; }
        public int UkupnoObjava { get; set; }
        public bool Aktivno { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Udruzenje, UdruzenjeViewModel>()
               .ForMember(dest => dest.Mjesto, opt => opt.MapFrom(src => src.AdministrativnaJedinica.Naziv))
               .ForMember(dest => dest.RibolovackiSavez, opt => opt.MapFrom(src => src.NadredjenoUdruzenje.Naziv))
               .ForMember(dest => dest.UkupnoObjava, opt => opt.MapFrom(src => src.ObjaveUdruzenjas.Count()))
               .ForMember(dest => dest.UkupnoClanova, opt => opt.MapFrom(src => src.Korisniks.Count()))
            ;
        }
    }
}
