namespace Formation.Infrastructure.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
}
