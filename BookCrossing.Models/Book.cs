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
        public string BookImagePath { get; set; }
        public string ISBN { get; set; }

        //public virtual IEnumerable<BookShelf> BookShelves { get; set; }

        public int ShelfId { get; set; }
        public virtual Shelf? Shelf { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual IEnumerable<Writer> Writers { get; set; }
        public virtual IEnumerable<Genre> Genres { get; set; }
    }
}
