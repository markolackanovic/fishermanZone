using Application.Common.Interfaces;
using Application.Common.Models.Respones;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Roles.Commands
{
     public record CreateRolesCommand : IRequest<ServiceResponse>
    {
        public string Name { get; init; }
    }

    public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, ServiceResponse>
    {
        private readonly IApplicationDbContext _context;

        public CreateRolesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
          
                var entity = new Role
            {
                Name = request.Name,
            };

                _context.Set<Role>().Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return ServiceResponse.Success(entity);
           
        }
    }
}