using Application.Common.Mappings;
using Application.Shared.Services.Create;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BusinessLogic.TipDatoteke.Commands.CreateTipDatotekeCommand
{
    public class CreateTipDatotekeCommand : CreateCommand, IMapFrom<Domain.Entities.TipDatoteke>
    {
        public string Naziv { get; set; } = string.Empty;
    }
}