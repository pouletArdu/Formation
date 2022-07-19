namespace Formation.Application.Authors.Queries.GetOne;

public class GetOneAuthorQueryValidator : AbstractValidator<GetOneAuthorQuery>
{
    public GetOneAuthorQueryValidator()
    {
        RuleFor(a => a.Id).NotEmpty()
            .GreaterThan(0);
    }
}
