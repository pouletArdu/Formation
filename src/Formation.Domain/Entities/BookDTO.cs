﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Domain.Entities
{
    public class BookDTO : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public AuthorDTO Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int NumberOfPage { get; set; }
    }
}
