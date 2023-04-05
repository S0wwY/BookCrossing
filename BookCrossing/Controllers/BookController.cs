using BookCrossing.Application.Interfaces;
using BookCrossing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("BookById/{id}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            //var vm = _readBookMapper.Map(book);
            return book;
        }

        [HttpGet("BooksByGenreId/{id}")]
        public async Task<IList<Book>> GetBookByGenreIdAsync(int id)
        {
            var books = await _bookService.GetBooksByGenreId(id);
            //var vm = _readBookMapper.Map(book);
            return books;
        }

        [HttpGet("BooksByWriterId/{id}")]
        public async Task<IList<Book>> GetBookByWriterIdAsync(int id)
        {
            var books = await _bookService.GetBooksByWriterId(id);
            //var vm = _readBookMapper.Map(book);
            return books;
        }

        [HttpGet("BooksByPublisher")]
        public async Task<IList<Book>> GetBookByPublisherAsync(string publisher)
        {
            var books = await _bookService.GetBooksByPublisher(publisher);
            //var vm = _readBookMapper.Map(book);
            return books;
        }
    }
}
