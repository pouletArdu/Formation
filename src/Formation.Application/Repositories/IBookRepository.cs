namespace Formation.Application.Repositories;

public interface IBookRepository
{
    public Task<int> Add(BookDTO dto);

    public Task<BookDTO> GetOneBookById(int id);

    public Task<IEnumerable<BookDTO>> GetAllBook();
}
