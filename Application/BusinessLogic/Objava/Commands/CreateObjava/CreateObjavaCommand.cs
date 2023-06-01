using Application.Common.Mappings;
using AutoMapper;
using MediatR;
using Application.Shared.Services.Create;

namespace Application.BusinessLogic.Objava.Commands.CreateObjava;

public class CreateObjavaCommand : CreateCommand , IMapFrom<Domain.Entities.Objava>
{
    
    public string? Naslov { get; set; }
    public string Sadrzaj { get; set; }
    public DateOnly? DatumObjave { get; set; }
    public string LokacijaLat { get; set; }
    public string LokacijaLong { get; set; }
    public int TipObjaveId { get; set; }

}
