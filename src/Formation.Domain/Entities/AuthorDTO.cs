using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Domain.Entities
{
    public class AuthorDTO : BaseEntity
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateOnly Birthday { get; set; }

        public Gender gender { get; set; }

        public ICollection<BookDTO> Books { get; set; }
    }
}
