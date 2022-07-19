namespace Formation.Application.Authors.Queries;

public interface IAuthorService
{
    Task<AuthorDTO> GetOneAuthorAsync(int id, CancellationToken cancellationToken);
}
