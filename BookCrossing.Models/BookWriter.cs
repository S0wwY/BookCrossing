using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class BookWriter : BaseEntity
    {
        public int BookId { get; set; }
        public int WriterId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
