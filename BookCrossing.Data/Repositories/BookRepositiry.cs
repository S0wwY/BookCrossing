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
    public class BookRepositiry : BaseRepository<Book>, IBookRepository
    {
        public BookRepositiry(DataContext context) : base(context)
        {
            
        }

        public async Task<IList<Book>> GetBooksByGenreAsync(int genreId)
        {
            var books = await dataContext.Books
                .Where(b => b.BookGenres
                    .Select(bg => bg.GenreId)
                    .Contains(genreId)).ToListAsync();

            return books;
        }

        public async Task<IList<Book>> GetBooksByWriterAsync(int writerId)
        {
            var books = await dataContext.Books
                .Where(b => b.BookWriters
                    .Select(bg => bg.WriterId)
                    .Contains(writerId)).ToListAsync();

            return books;
        }

        public async Task<IList<Book>> GetBooksByPublisherAsync(string publisher)
        {
            var books = await dataContext.Books
                .Where(b => b.Publisher.Contains(publisher))
                .ToListAsync();

            return books;
        }
    }
}
