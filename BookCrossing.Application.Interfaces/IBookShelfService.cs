using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookCrossing.Application.Interfaces
{
    public interface IBookShelfService
    {
        Task PutOnShelfAsync(int bookId, int shelfId = 0);
        Task ReserveAsync(int bookId, User requestUser);
        //Task TakeFromShelfAsync(int bookId, User requestUser);
        //Task TakeFromShelfAsync(int bookId);
    }
}
