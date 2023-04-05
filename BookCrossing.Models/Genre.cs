using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
}
}
