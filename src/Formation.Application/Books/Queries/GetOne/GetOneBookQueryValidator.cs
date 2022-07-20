namespace Formation.Application.Books.Queries.GetOne;

public class GetOneBookQueryValidator : AbstractValidator<GetOneBookQuery>
{
    public GetOneBookQueryValidator()
    {
        RuleFor(a => a.Id).NotEmpty()
            .GreaterThan(0);
    }
}
