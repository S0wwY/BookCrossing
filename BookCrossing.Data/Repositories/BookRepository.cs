using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.Extentions;
using BookCrossing.Data.Data;
using BookCrossing.Data.Extentions;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using BookCrossing.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<IList<Book>> GetBooksByGenreAsync(int genreId)
        {
            //var books = await dataContext.Books
            //    .Where(b => b.BookGenres
            //        .Select(bg => bg.GenreId)
            //        .Contains(genreId)).ToListAsync();
            var books = await dataContext.Books
                .Include(b => b.Genres
                    .Where(g => g.Id == genreId)).ToListAsync();

            return books;
        }

        public async Task<IList<Book>> GetBooksByWriterAsync(int writerId)
        {
            //var books = await dataContext.Books
            //    .Where(b => b.BookWriters
            //        .Select(bg => bg.WriterId)
            //        .Contains(writerId)).ToListAsync();

            var books = await dataContext.Books
                .Include(b => b.Writers
                    .Where(w => w.Id== writerId)).ToListAsync();

            return books;
        }

        public async Task<IList<Book>> GetBooksByPublisherAsync(string publisher)
        {
            var books = await dataContext.Books
                .Where(b => b.Publisher.Contains(publisher))
                .ToListAsync();

            return books;
        }

        public PagedList<Book> GetBooks(BookParameters bookParameters)
        {
            return PagedList<Book>.ToPagedList(FindAll().OrderBy(on => on.BookName),
                bookParameters.PageNumber,
                bookParameters.PageSize);
        }

        public async Task<PagedList<BookViewModel>> GetWithFiltersAsync(BookParameters bookParameters)
        {
            IQueryable<Book> bookEntity = dataContext.Books
                .Include(b => b.Genres)
                .Include(b => b.Writers);

            var books = await bookEntity//.FilterByAuthors(bookParameters.Writers)
            //var books = await dataContext.Books//.FilterByAuthors(bookParameters.Writers)
                //.FilterByDates(bookParameters.FromDateTime, bookParameters.ToDateTime)
                .FilterByCategoryId(bookParameters.CategoryId)
                //.Search(bookParameters.SearchTerm)
                .Sort(bookParameters.OrderString)
                .ToListAsync();

            var pagedBooks = ViewModelExtentions.CreateBookViewModel(books);

            return PagedList<BookViewModel>.ToPagedList(pagedBooks, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<IList<Book>> GetBooksByShelfNameAsync(string shelfName)
        {
            var books = await dataContext.Books
                .Where(b => b.Shelf.ShelfName == shelfName)
                .ToListAsync();

            return books;
        }

        public async Task<IList<BookViewModel>> GetBooksByUserId(Guid userId)
        {
            var books = await dataContext.Books.Where(b => b.UserId.Equals(userId)).ToListAsync();

            var bookVm = ViewModelExtentions.CreateBookViewModel(books);

            return bookVm;
        }

    }
}
