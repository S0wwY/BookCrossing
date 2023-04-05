using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;


namespace BookCrossing.Application.Interfaces
{
    public interface IBookService
    {
        //Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters);
        Task<IList<Book>> GetBooksByGenreId(int genreId);
        Task<IList<Book>> GetBooksByWriterId(int writerId);
        Task<IList<Book>> GetBooksByPublisher(string publisher);
        Task<Book> GetBookByIdAsync(int bookId);
    }
}
