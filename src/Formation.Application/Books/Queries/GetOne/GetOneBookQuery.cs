
namespace Formation.Application.Books.Queries.GetOne
{
    public class GetOneBookQuery : IRequest<BookDTO>
    {
        public int Id { get; set; }

        public GetOneBookQuery(int id)
        {
            Id = id;
        }
    }
}