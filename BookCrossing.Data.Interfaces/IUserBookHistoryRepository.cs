using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Data.Interfaces
{
    public interface IUserBookHistoryRepository : IBaseRepository<UserBookHistory>
    {
        Task<IList<UserBookHistory>> GetUserBooksHistory(Guid userId);
    }
}
