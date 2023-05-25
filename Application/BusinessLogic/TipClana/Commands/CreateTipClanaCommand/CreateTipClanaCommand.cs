using Application.Common.Mappings;
using AutoMapper;
using MediatR;
using Application.Shared.Services.Create;

namespace Application.BusinessLogic.TipClana.Commands.CreateTipClanaCommand;

public class CreateTipClanaCommand : CreateCommand , IMapFrom<Domain.Entities.TipClana>
{
    public string Naziv { get; set; }
    public bool Aktivno { get; set; }
}
