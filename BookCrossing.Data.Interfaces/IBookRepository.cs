using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Data.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IList<Book>> GetBooksByGenreAsync(int genreId);
        Task<IList<Book>> GetBooksByWriterAsync(int writerId);
        Task<IList<Book>> GetBooksByPublisherAsync(string publisher);

    }
}
