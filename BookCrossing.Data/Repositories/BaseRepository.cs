using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Data.Data;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext dataContext;

        public BaseRepository(DataContext DataContext)
        {
            this.dataContext = DataContext;
        }

        public void Delete(T entity) => dataContext.Set<T>().Remove(entity);

        public async Task<IList<T>> GetAllAsync() =>
            await dataContext.Set<T>().ToListAsync();

        public virtual async Task<T> GetByIdAsync(int id) =>
            await dataContext.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();

        public void Insert(T entity) => dataContext.Set<T>().Add(entity);

        public void Update(T entity) => dataContext.Set<T>().Update(entity);

        public async Task SaveAsync() => await dataContext.SaveChangesAsync();
    }
}
