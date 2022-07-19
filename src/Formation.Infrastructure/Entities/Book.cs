using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Entities
{
    public class Book : Common.BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public DateTime PublicationDate { get; set; }

        public int NumberOfPage { get; set; }
    }
}
