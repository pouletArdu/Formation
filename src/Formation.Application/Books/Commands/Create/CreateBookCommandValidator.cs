using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(a => a.Title)
                .NotNull().WithMessage("Title could not be null")
                .NotEmpty().WithMessage("Title could not be null");

            RuleFor(a => a.NumberOfPage)
                .GreaterThan(0);

            RuleFor(a => a.AuthorId)
                .GreaterThan(0).WithMessage("Author could not be null");
        }
    }
}
