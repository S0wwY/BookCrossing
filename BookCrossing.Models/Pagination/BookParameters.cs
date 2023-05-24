using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models.Pagination
{
    public class BookParameters : QueryStringParameters
    {
        public string SearchTerm { get; set; }
        public string Publisher { get; set; }
        public ICollection<string> Writers { get; set; }
        public int CategoryId { get; set; }

        public BookParameters()
        {
            OrderString = "BookName";
        }
    }
}
