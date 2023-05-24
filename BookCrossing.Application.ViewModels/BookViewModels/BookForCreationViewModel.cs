using BookCrossing.Application.ViewModels.AuthorViewModels;
using BookCrossing.Application.ViewModels.GenreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Application.ViewModels.BookViewModels
{
    public class BookForCreationViewModel
    {
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string BookImagePath { get; set; }
        public string ISBN { get; set; }
        public int ShelfId { get; set; }
        public IList<WriterViewModel> Writers { get; set; }
        public IList<GenreViewModel> Genres { get; set; }
    }
}
