using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Infrastructure.Entities
{
    public class Author : Common.BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
