using BookCrossing.Application.Interfaces;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.UserBookHistoryViewModels;
using BookCrossing.Models;
using BookCrossing.Models.Email;
using BookCrossing.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IBookShelfService _bookShelfService;
        public BookController(IBookService bookService, IEmailSenderService emailSenderService, IBookShelfService bookShelfService)
        {
            _bookService = bookService;
            _emailSenderService = emailSenderService;
            _bookShelfService = bookShelfService;
        }

        [HttpPost("AddBook")]
        //[Authorize]
        public async Task<IActionResult> AddBookAsync(BookForCreationViewModel newBook)
        {
            await _bookService.AddBookAsync(newBook);
            return Ok();
        }

        [HttpGet("userBooks")]
        public async Task<IList<BookViewModel>> GetUserBooks()
        {
            var books = await _bookService.GetUserBooks();
            return books;
        }

        [HttpGet("BooksHistory")]
        public async Task<IList<UserBookHistoryViewModel>> GetBooksHistory()
        {
            var books = await _bookService.GetUserBooksHistory();

            return books;
        }

        //[HttpGet("Email")]
        //public IActionResult Get()
        //{
        //    var message = new Message(new string[] { "vladtaras982@mail.ru" }, "Test email", "This is the content from our email.");
        //    _emailSenderService.SendEmail(message);

        //    return Ok();
        //}

        [HttpGet("GetAllBooks")]
        public async Task<IList<BookViewModel>> GetAllBooks()
        {
            var booksVm = await _bookService.GetAllBooksAsync();
            return booksVm;
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<BookViewModel> GetBookByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book;
        }

        [HttpGet("GetBooksByShelf")]
        public async Task<IList<BookViewModel>> GetBooksByShelf([FromQuery] string shelfName)
        {
            var booksVm = await _bookService.GetBooksByShelfNameAsync(shelfName);

            return booksVm;
        }

        [HttpGet("GetFilteredBooks")]
        public async Task<PagedList<BookViewModel>> GetFilteredBooks([FromQuery] BookParameters bookParameters)
        {
            var books = await _bookService.GetFilteredBooksAsync(bookParameters);

            return books;
        }

        [HttpGet("BooksByGenreId/{id}")]
        public async Task<IList<Book>> GetBookByGenreIdAsync(int id)
        {
            var books = await _bookService.GetBooksByGenreIdAsync(id);
            return books;
        }

        [HttpGet("BooksByWriterId/{id}")]
        public async Task<IList<Book>> GetBookByWriterIdAsync(int id)
        {
            var books = await _bookService.GetBooksByWriterIdAsync(id);
            return books;
        }

        [HttpGet("BooksByPublisher")]
        public async Task<IList<Book>> GetBookByPublisherAsync(string publisher)
        {
            var books = await _bookService.GetBooksByPublisherAsync(publisher);
            return books;
        }

        [HttpPost("PutBook")]
        public async Task PutBookInShelf(int bookId, int shelfId)
        {
            await _bookShelfService.PutOnShelfAsync(bookId, shelfId);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task DeleteBookById(int id)
        {
            await _bookService.DeleteBookById(id);
        }
        //[HttpPost("TakeBookFromShelf")]
        //public async Task TakeBookFromShelf(int bookId)
        //{
        //    await _bookShelfService.TakeFromShelfAsync(bookId);
        //}
    }
}
