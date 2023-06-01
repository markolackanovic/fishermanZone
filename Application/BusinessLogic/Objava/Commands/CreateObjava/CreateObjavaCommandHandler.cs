using Application.Shared.Services.Create;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.BusinessLogic.Objava.Commands.CreateObjava;

public class CreateObjavaCommandHandler : CreateCommandHandler<CreateObjavaCommand,Domain.Entities.Objava>
{
    public CreateObjavaCommandHandler(IApplicationDbContext context,IMapper mapper) : base(context,mapper)    
    {
    }

}
