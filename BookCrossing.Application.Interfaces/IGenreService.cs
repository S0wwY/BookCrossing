using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Application.Interfaces
{
    public interface IGenreService
    {
        Task<Genre> GetByIdAsync(int genreId);
        Task CreateGenreAsync(Genre newGenre);
        Task DeleteGenreAsync(int genreId);
        Task UpdateGenreAsync(Genre updateGenre);
    }
}
