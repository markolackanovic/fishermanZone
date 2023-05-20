using Application.BusinessLogic.Shared.Create;
using Application.Common.Mappings;
using AutoMapper;
using MediatR;

namespace Application.BusinessLogic.TipAdministrativneJedinice.Commands.CreateTipAdministrativneJediniceCommand;

public class CreateTipAdministrativneJediniceCommand : CreateCommand , IMapFrom<Domain.Entities.TipAdministrativneJedinice>
{
    public string Naziv { get; set; }
    public bool Aktivno { get; set; }
}
