using BookCrossing.Application.Interfaces;
using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Data.Interfaces;

namespace BookCrossing.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);

            return book;
        }

        public async Task<IList<Book>> GetBooksByGenreId(int genreId)
        {
            var books = await _bookRepository.GetBooksByGenreAsync(genreId);

            return books;
        }

        public async Task<IList<Book>> GetBooksByPublisher(string publisher)
        {
            var books = await _bookRepository.GetBooksByPublisherAsync(publisher);

            return books;
        }

        public async Task<IList<Book>> GetBooksByWriterId(int writerId)
        {
            var books = await _bookRepository.GetBooksByWriterAsync(writerId);

            return books;
        }
    }
}
