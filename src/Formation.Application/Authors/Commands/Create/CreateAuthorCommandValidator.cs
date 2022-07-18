using FluentValidation;

namespace Formation.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.FirstName)
                .NotNull().WithMessage("{PropertyName} could not be null")
                .NotEmpty().WithMessage("{PropertyName} could not be empty");

            RuleFor(a => a.LastName)
                .NotNull().WithMessage("{PropertyName} could not be null")
                .NotEmpty().WithMessage("{PropertyName} not be empty");

            RuleFor(a => a.Birthday)
                .LessThan(DateTime.Now).WithMessage("{PropertyName} less than now");

        }
    }
}
