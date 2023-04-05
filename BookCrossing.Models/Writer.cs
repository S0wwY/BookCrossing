using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class Writer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<BookWriter> BookWriters { get; set; }
    }
}
