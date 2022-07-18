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
                .NotNull().WithMessage("First Name could not be null")
                .NotEmpty().WithMessage("First Name could not be null");

            RuleFor(a => a.LastName)
                .NotNull().WithMessage($"Last Name could not be null")
                .NotEmpty().WithMessage("Last Name could not be null");


            RuleFor(a => a.Birthday).LessThan(DateTime.Now);
        }
    }
}
