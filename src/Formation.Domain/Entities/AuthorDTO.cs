namespace Formation.Domain.Entities;

public class AuthorDTO : BaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender gender { get; set; }
    public ICollection<BookDTO> Books { get; set; }
}
