using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;

namespace BookCrossing.Application.Services
{
    public class BookShelfService : IBookShelfService
    {
        private readonly IBookShelfRepository _bookShelfRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserContext _userContext;

        public BookShelfService(IBookShelfRepository bookShelfRepository,
            IBookRepository bookRepository,
            IUserContext userContext)
        {
            _bookShelfRepository = bookShelfRepository;
            _bookRepository = bookRepository;  
            _userContext = userContext;
        }

        public async Task PutOnShelfAsync(int bookId, int shelfId = 0)
        {
            var book = await _bookRepository.FirstOrDefault(bk => bk.Id == bookId);

            BookShelf bookShelf = new BookShelf();

            bookShelf.BookId = book.Id;
            bookShelf.ShelfId = shelfId;

            _bookShelfRepository.Insert(bookShelf);
            await _bookShelfRepository.SaveAsync();
        }

        public async Task ReserveAsync(int bookId, User requestUser)
        {
            throw new NotImplementedException();
        }
        //добавить проверку занята ли книга 
        //public async Task TakeFromShelfAsync(int bookId, User requestUser)
        //{
        //    //var book = await _bookRepository.FirstOrDefault(bc => bc.Id == bookId);

        //    BookUser bookUser = new BookUser();

        //    bookUser.UserId = requestUser.Id;
        //    bookUser.User = requestUser;
        //    bookUser.BookId = bookId;
        //    bookUser.DateOfAdded = DateTime.Now;
        //    bookUser.DateOfRemoved = DateTime.Now;//изменить и сделать необязательным параметром

        //    _bookUserRepository.Insert(bookUser);
        //    await _bookUserRepository.SaveAsync();
        //}
        //добавить проверку занята ли книга 

        //public async Task TakeFromShelfAsync(int bookId)
        //{
        //    //var book = await _bookRepository.FirstOrDefault(bc => bc.Id == bookId);

        //    //BookUser bookUser = new BookUser();

        //    bookUser.UserId = _userContext.UserId;
        //    bookUser.BookId = bookId;
        //    bookUser.DateOfAdded = DateTime.Now;

        //    //добавить какой нибудь enum для отображения статуса книги

        //    //var bookShelf = await _bookShelfRepository.GetShelfByBookIdAsync(bookId);

        //    //bookShelf.ShelfId = null;

        //    //_bookShelfRepository.Update(bookShelf);
        //    //await _bookShelfRepository.SaveAsync();

        //    _bookUserRepository.Insert(bookUser);
        //    await _bookUserRepository.SaveAsync();
        //}
    }
}
