using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Roles.Commands
{
    public class CreateRolesCommandValidator : AbstractValidator<CreateRolesCommand>
    {
        public CreateRolesCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Rola ne smije biti prazna");
        }
    }
}
