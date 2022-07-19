namespace Formation.Infrastructure.Entities;

public class Author : Common.BaseEntity
{
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public DateTime Birthday { get; set; }

    public Gender Gender { get; set; }

    public ICollection<Book> Books { get; set; }
}
