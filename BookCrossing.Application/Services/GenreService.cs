using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;

namespace BookCrossing.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> GetByIdAsync(int genreId)
        {
            var genre = await _genreRepository.GetByIdAsync(genreId);

            if (genre is null)
            {
                throw new Exception($"There is no category with id {genreId}");
            }

            return genre;
        }

        public async Task CreateGenreAsync(Genre newGenre)
        {
            _genreRepository.Insert(newGenre);
            await _genreRepository.SaveAsync();
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            var genreToDelete = await _genreRepository.GetByIdAsync(genreId);

            _genreRepository.Delete(genreToDelete);
            await _genreRepository.SaveAsync();
        }

        public async Task UpdateGenreAsync(Genre updateGenre)
        {
            var genreToUpdate = await _genreRepository.GetByIdAsync(updateGenre.Id);

            if (updateGenre is null)
            {
                throw new Exception($"There is no category with id {updateGenre}");
            }

            genreToUpdate.Name = updateGenre.Name;

            _genreRepository.Update(genreToUpdate);
            await _genreRepository.SaveAsync();
        }
    }
}
