using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task SaveAsync();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
