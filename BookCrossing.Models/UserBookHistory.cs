using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models
{
    public class UserBookHistory : BaseEntity
    {
        public string BookName { get; set; }
        public string ShelfName { get; set; }
        public string DateOfPickedUp { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
