using BookCrossing.Application.Interfaces;
using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.Extentions;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models.Pagination;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;
using BookCrossing.Application.ViewModels.ShelfViewModels;
using BookCrossing.Application.ViewModels.UserBookHistoryViewModels;

namespace BookCrossing.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserContext _userContext;
        private readonly IShelfRepository _shelfRepository;
        private readonly IUserBookHistoryRepository _userBookHistoryRepository;

        public BookService(IBookRepository bookRepository,
            IUserContext userContext,
            IShelfRepository shelfRepository,
            IUserBookHistoryRepository sBookHistoryRepository)
        {
            _bookRepository = bookRepository;
            _userContext = userContext;
            _shelfRepository = shelfRepository;
            _userBookHistoryRepository = sBookHistoryRepository;
        }

        public async Task AddBookAsync(BookForCreationViewModel newBook)
        {

            //var shelfId = _shelfRepository.GetShelfByName(newBook.ShelfName);
            var bookEntity = ToBookModel(newBook);

            _bookRepository.Insert(bookEntity);
            await _bookRepository.SaveAsync();

        }

        public async Task<BookViewModel> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            var bookVm = ToBookVmModel(book);
            return bookVm;
        }

        public async Task DeleteBookById(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);

            UserBookHistory bookHistory = new UserBookHistory()
            {
                BookName = book.BookName,
                ShelfName = book.Shelf.ShelfName,
                DateOfPickedUp = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm"),
                UserId = _userContext.UserId,
            };

            _userBookHistoryRepository.Insert(bookHistory);
            await _userBookHistoryRepository.SaveAsync();

            _bookRepository.Delete(book);
             await _bookRepository.SaveAsync();
        }

        public async Task<IList<UserBookHistoryViewModel>> GetUserBooksHistory()
        {
            var userId = _userContext.UserId;

            var bookEntity = await _userBookHistoryRepository.GetUserBooksHistory(userId);

            var booksVm = ViewModelExtentions.CreateBookHistoryViewModel(bookEntity);

            return booksVm;
        }

        public PagedList<Book> GetPagedBooks(BookParameters parameters)
        {
            //return PagedList<Book>.ToPagedList(FindAll().OrderBy(on => on.Name),
            //    ownerParameters.PageNumber,
            //    ownerParameters.PageSize);
            var pagedBooks =   _bookRepository.GetBooks(parameters);

            return pagedBooks;
        }

        public async Task<IList<Book>> GetBooksByGenreIdAsync(int genreId)
        {
            var books = await _bookRepository.GetBooksByGenreAsync(genreId);

            return books;
        }

        public async Task<IList<Book>> GetBooksByPublisherAsync(string publisher)
        {
            var books = await _bookRepository.GetBooksByPublisherAsync(publisher);

            return books;
        }

        public async Task<IList<Book>> GetBooksByWriterIdAsync(int writerId)
        {
            var books = await _bookRepository.GetBooksByWriterAsync(writerId);
            return books;
        }

        public async Task<PagedList<BookViewModel>> GetFilteredBooksAsync(BookParameters parameters)
        {
            var books = await _bookRepository.GetWithFiltersAsync(parameters);

            return books;
        }

        public async Task<IList<BookViewModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var bookVm = ViewModelExtentions.CreateBookViewModel(books);

            return bookVm;
        }

        public async Task<IList<BookViewModel>> GetBooksByShelfNameAsync(string shelfName)
        {
            var books = await _bookRepository.GetBooksByShelfNameAsync(shelfName);

            var booksVm = ViewModelExtentions.CreateBookViewModel(books);

            return booksVm;
        }

        public async Task<IList<BookViewModel>> GetUserBooks()
        {
            var userId = _userContext.UserId;
            var books = await _bookRepository.GetBooksByUserId(userId);

            return books;
        }

        public static BookViewModel ToBookVmModel(Book book)
        {
            BookViewModel bookVm = new BookViewModel(book);

            return bookVm;
        }

        public Book ToBookModel(BookForCreationViewModel newBook)
        {

            //var shelfId = _shelfRepository.GetShelfByName(newBook.ShelfName);

            Book book = new Book()
            {
                BookName = newBook.BookName,
                Description = newBook.Description,
                Publisher = newBook.Publisher,
                BookImagePath = newBook.BookImagePath,
                ISBN = newBook.ISBN,
                ShelfId = newBook.ShelfId,
                UserId = _userContext.UserId,
                Writers = newBook.Writers.Select(s => new Writer()
                {
                    //Id = s.Id,
                    FullName = s.FullName
                }).ToList(),

                Genres = newBook.Genres.Select(s => new Genre()
                {
                    //Id = s.Id,
                    Name = s.Name
                }).ToList()
            };

            return book;
        }
    }
}
