using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.ViewModels.AuthorViewModels;
using BookCrossing.Application.ViewModels.GenreViewModels;

namespace BookCrossing.Application.ViewModels.Extentions
{
    public static class ViewModelExtentions
    {
        public static List<BookViewModel> CreateBookViewModel(IList<Book> books)
        {
            List<BookViewModel> booksVm = new List<BookViewModel>();

            foreach (var book in books)
            {
                booksVm.Add(new BookViewModel(book));
            }

            return booksVm;
        }

        //public static Book ToBookModel(BookForCreationViewModel newBook)
        //{
        //    Book book = new Book()
        //    {
        //        BookName = newBook.BookName,
        //        Description = newBook.Description,
        //        Publisher = newBook.Publisher,
        //        BookImagePath = newBook.BookImagePath,
        //        ISBN = newBook.ISBN,
        //        Writers = newBook.Writers.Select(s => new Writer()
        //        {
        //        //Id = s.Id,
        //        FullName = s.FullName
        //        }).ToList(),
        //        Genres = newBook.Genres.Select(s => new Genre()
        //        {
        //            //Id = s.Id,
        //            Name = s.Name
        //        }).ToList()
        //    };

        //    return book;
        //}
    }
}
