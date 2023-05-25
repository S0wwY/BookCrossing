using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Application.ViewModels.UserBookHistoryViewModels
{
    public class UserBookHistoryViewModel
    {
        public string BookName { get; set; }
        public string ShelfName { get; set; }
        public string DateOfPickedUp { get; set; }

        public UserBookHistoryViewModel(UserBookHistory book)
        {
            BookName = book.BookName;
            ShelfName = book.ShelfName;
            DateOfPickedUp = book.DateOfPickedUp;
        }
    }
}
