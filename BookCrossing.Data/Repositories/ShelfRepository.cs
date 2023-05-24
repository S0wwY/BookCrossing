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
    public class ShelfRepository : BaseRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(DataContext context) : base(context)
        {

        }

        public async Task<int> GetShelfByName(string shelfName)
        {
            var shelf = await dataContext.Shelves.FirstOrDefaultAsync(s => s.ShelfName == shelfName);

            int shelfId = shelf.Id;

            return shelfId;
        }
    }
}
