namespace Formation.Application.Repositories;

public interface IBookRepository
{
    public Task<int> Add(BookDTO dto);
}
