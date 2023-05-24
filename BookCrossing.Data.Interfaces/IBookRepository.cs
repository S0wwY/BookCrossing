using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Models;
using BookCrossing.Models.Pagination;

namespace BookCrossing.Data.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IList<Book>> GetBooksByGenreAsync(int genreId);
        Task<IList<Book>> GetBooksByWriterAsync(int writerId);
        Task<IList<Book>> GetBooksByPublisherAsync(string publisher);
        Task<IList<Book>> GetBooksByShelfNameAsync(string shelfName);
        PagedList<Book> GetBooks(BookParameters bookParameters); // delete
        Task<PagedList<BookViewModel>> GetWithFiltersAsync(BookParameters postParameters);
        Task<IList<BookViewModel>> GetBooksByUserId(Guid userId);
    }
}
