using MediatR;

namespace Application.BusinessLogic.Shared.Queries.GetByID
{
    public class GetByIdQuery<TViewModel> : IRequest<TViewModel>
        where TViewModel : class
    {
        public int Id { get; set; }
    }
}
