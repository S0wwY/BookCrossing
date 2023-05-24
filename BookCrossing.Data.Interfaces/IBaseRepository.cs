using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models.Pagination;

namespace BookCrossing.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task SaveAsync();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> FindAll();
    }
}
