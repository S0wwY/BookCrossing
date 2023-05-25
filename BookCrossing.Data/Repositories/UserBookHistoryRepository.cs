using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Repositories
{
    public class UserBookHistoryRepository : BaseRepository<UserBookHistory>, IUserBookHistoryRepository
    {
        public UserBookHistoryRepository(DataContext options) : base(options)
        {
            
        }

        public async Task<IList<UserBookHistory>> GetUserBooksHistory(Guid userId)
        {
            var books = await dataContext.UserBooks
                .Where(b => b.UserId.Equals(userId)).ToListAsync();

            return books;
        }
    }
}
