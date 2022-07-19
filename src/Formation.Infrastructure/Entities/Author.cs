namespace Formation.Infrastructure.Entities;

public class Author : Common.BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }
    public ICollection<BookDTO> Books { get; set; }
}
