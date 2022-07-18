namespace Formation.Domain.Entities;

public class AuthorDTO : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }
    public ICollection<BookDTO> Books { get; set; }

    public override string ToString()
    {
        return $"{(Gender == Gender.Male ? "Mr" : "Mdm")} {FirstName} {LastName}";
    }
}
