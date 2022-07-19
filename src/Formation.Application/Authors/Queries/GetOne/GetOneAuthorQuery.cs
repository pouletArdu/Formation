namespace Formation.Application.Authors.Queries.GetOne
{
    public class GetOneAuthorQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }
        public GetOneAuthorQuery(int id)
        {
            Id = id;
        }
    }
}
