using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
        public string BookImagePath { get; set; }
        public int PageCount { get; set; }

        public virtual ICollection<BookWriter> BookWriters { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}
