using MediatR;

namespace Application.Shared.Services.Queries.GetByID
{
    public class GetByIdQuery<TViewModel> : IRequest<TViewModel>
        where TViewModel : class
    {
        public int Id { get; set; }
    }
}
