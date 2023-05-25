using Application.BusinessLogic.Shared.Create;
using Application.Common.Mappings;
using AutoMapper;
using MediatR;

namespace Application.BusinessLogic.TipClana.Commands.CreateTipClanaCommand;

public class CreateTipClanaCommand : CreateCommand , IMapFrom<Domain.Entities.TipClana>
{
    public string Naziv { get; set; }
    public bool Aktivno { get; set; }
}
