using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.FirstName)
                .NotNull().WithMessage("First name could not be null")
                .NotEmpty().WithMessage("First name could not be null");

            RuleFor(a => a.LastName)
                .NotNull().WithMessage("Last name could not be null")
                .NotEmpty().WithMessage("Last name could not be null");

            RuleFor(a => a.BirthDate)
                .LessThan(DateTime.Now);
        }
    }
}
