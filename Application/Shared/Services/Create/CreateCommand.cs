using MediatR;

namespace Application.Shared.Services.Create
{
    public class CreateCommand : IRequest<int>
    {
        public bool Aktivno { get; set; } = true;
    }

}
