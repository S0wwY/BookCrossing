using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Data.Interfaces
{
    public interface IBookShelfRepository : IBaseRepository<BookShelf>
    {
        //Task<BookShelf> GetShelfByBookIdAsync(int bookId);
    }
}
