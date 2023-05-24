using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Application.Interfaces
{
    public interface IWriterService
    {
        Task AddWriterAsync(Writer newWriter);
        Task UpdateWriterAsync(Writer updateWriter);
        Task DeleteWriterAsync(int writerId);
        Task<Writer> GetWriterByIdAsync(int writerId);
    }
}
