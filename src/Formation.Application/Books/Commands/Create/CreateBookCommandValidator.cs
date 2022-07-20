using FluentValidation;

namespace Formation.Application.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateBookCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(a => a.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(a => a.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(a => a.AuthorId)
                .NotEmpty()
                .GreaterThan(0);                

            RuleFor(a => a.PublicationDate)
                .LessThan(DateTime.Now).WithMessage("{PropertyName} less than now");

            RuleFor(x => x.AuthorId).MustAsync(AuthorShouldExist);

        }

        private async Task<bool> AuthorShouldExist(int authorId, CancellationToken arg2)
        {
            var result = await _authorRepository.GetOneAuthorById(authorId);
            return result != null;
        }
    }
}
