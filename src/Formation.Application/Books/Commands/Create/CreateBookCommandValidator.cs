using FluentValidation;

namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            //RuleFor(a => a.FirstName)
            //    .NotNull().WithMessage("{PropertyName} could not be null")
            //    .NotEmpty().WithMessage("{PropertyName} could not be empty");

            //RuleFor(a => a.LastName)
            //    .NotNull().WithMessage("{PropertyName} could not be null")
            //    .NotEmpty().WithMessage("{PropertyName} not be empty");

            //RuleFor(a => a.Birthday)
            //    .LessThan(DateTime.Now).WithMessage("{PropertyName} less than now");

        }
    }
}
