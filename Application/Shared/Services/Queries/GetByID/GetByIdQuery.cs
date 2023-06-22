using Application.Shared.Models;
using MediatR;

namespace Application.Shared.Services.Queries.GetByID
{
    public class GetByIdQuery<TViewModel> : IRequest<ServiceResult<TViewModel>>
        where TViewModel : class
    {
        public int Id { get; set; }
    }
}
