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

            RuleFor(a => a.Description)
                .NotNull().WithMessage("Description can not be null")
                .NotEmpty().WithMessage("Description can not be null");

            RuleFor(a => a.Author)
                .NotNull().WithMessage("Author can not be null")
                .NotEmpty().WithMessage("Author can not be null");
        }
    }
}
