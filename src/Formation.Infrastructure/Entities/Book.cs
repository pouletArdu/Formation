namespace Formation.Infrastructure.Entities
{
    public class Book : Common.BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public AuthorDTO Author { get; set; }

        public DateOnly PublicationDate { get; set; }

        public int NumberOfPage { get; set; }
    }
}
