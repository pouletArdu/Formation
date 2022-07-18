using Formation.Domain.Entities.Common;
namespace Formation.Domain.Entities;

public class AuthorDTO : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Gender Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<BookDTO> Books { get; set; }
}
