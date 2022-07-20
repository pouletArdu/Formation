using Formation.Application.Repositories;

namespace Application.Validation.Tests.Drivers
{
    public class BookRepositoryMock : BookRepository
    {
        public static List<BookDTO> Books = new List<BookDTO>();

        public async Task<int> Add(BookDTO dto)
        {
            await Task.Yield();
            Books.Add(dto);
            return Books.Count();
        }

        public static void Dispose()
        {
            Books.Clear();
        }

        public static void AddAuthors(IEnumerable<BookDTO> books)
        {
            Books.AddRange(books);
        }
    }
}
