using Application.Common.Interfaces;
using Application.Shared.Services.Delete;
using AutoMapper;

namespace Application.BusinessLogic.Objava.Commands.DeleteObjava
{
    public class DeleteObjavaCommandHandler : DeleteCommandHandler<DeleteObjavaCommand, Domain.Entities.Objava>
    {
        public DeleteObjavaCommandHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
