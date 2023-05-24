using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class Writer : BaseEntity
    {
        public string FullName { get; set; } // изменить на фио 
        //public string LastName { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
