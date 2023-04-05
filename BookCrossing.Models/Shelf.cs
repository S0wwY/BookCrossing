using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookCrossing.Models
{
    public class Shelf : BaseEntity
    {
        public string ShelfImagePath { get; set; }
        public string Adress { get; set; }
        public virtual IEnumerable<BookCopy> Books { get; set; }
        //public IEnumerable<HistoryRecord> HistoryRecords { get; set; }
    }
}
