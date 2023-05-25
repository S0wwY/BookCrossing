using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.UserBookHistoryViewModels;
using BookCrossing.Models;
using BookCrossing.Models.Pagination;


namespace BookCrossing.Application.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookViewModel>> GetAllBooksAsync();
        //Task<PagedList<Book>> GetFilteredBooksAsync(BookParameters parameters);
        Task<PagedList<BookViewModel>> GetFilteredBooksAsync(BookParameters parameters);
        Task<IList<Book>> GetBooksByGenreIdAsync(int genreId);
        Task<IList<Book>> GetBooksByWriterIdAsync(int writerId);
        Task<IList<Book>> GetBooksByPublisherAsync(string publisher);
        Task<BookViewModel> GetBookByIdAsync(int bookId);
        Task AddBookAsync(BookForCreationViewModel newBook);
        Task<IList<BookViewModel>> GetBooksByShelfNameAsync(string shelfName);
        Task<IList<BookViewModel>> GetUserBooks();
        Task<IList<UserBookHistoryViewModel>> GetUserBooksHistory();
        Task DeleteBookById(int bookId);
    }
}
