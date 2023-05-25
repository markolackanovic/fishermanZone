using Application.Common.Mappings;
using Application.Shared.Services.Create;

namespace Application.BusinessLogic.TipObjave.Commands.CreateTipObjaveCommand
{
    public class CreateTipObjaveCommand : CreateCommand, IMapFrom<Domain.Entities.TipObjave>
    {
        public string Naziv { get; set; }
        public bool Aktivno { get; set; }
    }
}