using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Data.Data;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Repositories
{
    public class BookShelfRepository : BaseRepository<BookShelf>, IBookShelfRepository
    {
        public BookShelfRepository(DataContext context) : base(context)
        {
            
        }

        //public  Task<BookShelf> GetShelfByBookIdAsync(int bookId)
        //{
        //    //var shelf =  dataContext.Shelves.
        //    //Where(s => s.BookShelves
        //    //    .Select(bs => bs.BookId)
        //    //    .Contains(bookId));
        //    //var bookShelf =  dataContext.Shelves.Where(s => s.BookShelves
        //    //    .Select(bs => bs.BookId)
        //    //    .Contains(bookId));
        //    var bookShelf = dataContext.BookShelves.FirstOrDefaultAsync(bs => bs.BookId == bookId);

        //    return bookShelf;
        //}
    }
}
