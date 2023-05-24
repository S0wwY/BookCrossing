using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;
using BookCrossing.Models.Pagination;
using System.Linq.Dynamic.Core;
using BookCrossing.Application.ViewModels.BookViewModels;

namespace BookCrossing.Data.Extentions
{
    public static class BookRepositoryExtentions
    {
        public static IQueryable<Book> FilterByAuthors(this IQueryable<Book> books, ICollection<string> authorsNames)
        {
            if (authorsNames == null)
            {
                return books;
            }

            //return books.Include(b => b.Writers.Where(w => authorsNames.Contains(w.FirstName)));
            return books.Where(b => b.Writers.Any(w => authorsNames.Contains(w.FullName)));
        }

        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return books;
            }

            return books.Where(b => b.Publisher.Contains(searchTerm)
                                    || b.BookName.Contains(searchTerm)
                                    || b.Writers.Any(w => w.FullName.Contains(searchTerm))
                                    || b.Genres.Any(g => g.Name.Contains(searchTerm)));
        }


        //public static IQueryable<Book> FilterByAuthorId(this IQueryable<Book> books, int authorId)
        //{
        //    if (authorId != 0)
        //    {
        //        return books.Where(p => p.BookWriters. == authorId);
        //    }
        //    return books;
        //}

        public static IQueryable<Book> FilterByCategoryId(this IQueryable<Book> books, int categoryId)
        {
            if (categoryId != 0)
            {
                return books.Where(b => b.Genres.Any(g => g.Id == categoryId));
            }
            return books;
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return books.OrderBy(b => b.BookName);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return books.OrderBy(x => x.BookName);
            }

            return books.OrderBy(orderQuery);
        }

        //public static List<BookViewModel> CreateBookViewModel(List<Book> books)
        //{
        //    List<BookViewModel> booksVm = new List<BookViewModel>();

        //    foreach (var book in books)
        //    {
        //        booksVm.Add(new BookViewModel(book));
        //    }

        //    return booksVm;
        //}
    }
}
