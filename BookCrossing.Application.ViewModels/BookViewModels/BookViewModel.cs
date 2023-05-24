using BookCrossing.Application.ViewModels.AuthorViewModels;
using BookCrossing.Application.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Application.ViewModels.BookViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string BookImagePath { get; set; }
        public string ISBN { get; set; }
        public string ShelfAdress { get; set; }
        public List<WriterViewModel> Writers { get; set; }
        public List<GenreViewModel> Genres { get; set; }

        public BookViewModel(Book book)
        {
            Id = book.Id;
            BookName = book.BookName;
            Description = book.Description;
            Publisher = book.Publisher;
            BookImagePath = book.BookImagePath;
            ISBN = book.ISBN;
            ShelfAdress = book.Shelf.Adress;
            Writers = book.Writers.Select(s => new WriterViewModel()
            {
                //Id = s.Id,
                FullName = s.FullName
            }).ToList();
            Genres = book.Genres.Select(s => new GenreViewModel()
            {
                //Id = s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}
