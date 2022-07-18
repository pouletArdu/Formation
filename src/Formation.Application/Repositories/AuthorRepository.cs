
namespace Formation.Application.Repositories
{
    public interface AuthorRepository
    {
        Task<int> Add(AuthorDTO dto);
    }
}
