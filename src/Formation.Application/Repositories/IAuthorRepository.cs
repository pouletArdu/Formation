namespace Formation.Application.Repositories;

public interface IAuthorRepository
{
    public Task<int> Add(AuthorDTO dto);

    public Task<AuthorDTO> GetOneAuthorById(int id);
}
