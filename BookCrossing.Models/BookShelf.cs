using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class BookShelf : BaseEntity
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int? ShelfId { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}
