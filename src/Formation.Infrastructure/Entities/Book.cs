﻿namespace Formation.Infrastructure.Entities
{
    public class Book : Common.BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int NumberOfPages { get; set; }
    }
}
