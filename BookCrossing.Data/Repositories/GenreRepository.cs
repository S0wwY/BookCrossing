using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Data.Data;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;

namespace BookCrossing.Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext context) : base(context)
        {
            
        }
    }
}
