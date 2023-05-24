using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.ShelfViewModels;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookCrossing.Application.Services
{
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfService(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }


        public async Task DeleteShelfByIdAsync(int shelfId)
        {
            var shelf = await _shelfRepository.GetByIdAsync(shelfId);

            if (shelf is null)
            {
                throw new Exception($"Shelf with id {shelfId} does not exist");
            }

            _shelfRepository.Delete(shelf);
            await _shelfRepository.SaveAsync();
        }

        public async Task<ShelfViewModel> GetShelfByIdAsync(int shelfId)
        {
            var shelf = await _shelfRepository.GetByIdAsync(shelfId);

            var shelfVm = ToShelfVmModel(shelf);

            return shelfVm;
        }

        public async Task AddShelfAsync(ShelfForCreationViewModel newShelf)
        {
            var shelfEntity = ToShelfModel(newShelf);

            _shelfRepository.Insert(shelfEntity);
            await _shelfRepository.SaveAsync();
        }

        public async Task<IList<ShelfViewModel>> GetShelves()
        {
            var shelves = await _shelfRepository.GetAllAsync();

            var shelvesVm = ToShelfVmModelList(shelves);

            return shelvesVm;
        }

        public static Shelf ToShelfModel(ShelfForCreationViewModel newShelf)
        {
            Shelf shelf = new Shelf()
            {
                Adress = newShelf.Adress,
                ShelfName = newShelf.ShelfName,
                ShelfImagePath = newShelf.ShelfImagePath
            };

            return shelf;
        }

        public static ShelfViewModel ToShelfVmModel(Shelf shelf)
        {
            ShelfViewModel shelfVm = new ShelfViewModel(shelf);

            return shelfVm;
        }

        public static List<ShelfViewModel> ToShelfVmModelList(IList<Shelf> shelves)
        {
            List<ShelfViewModel> shelfVm = new List<ShelfViewModel>();

            foreach (var shelf in shelves)
            {
                shelfVm.Add(new ShelfViewModel(shelf));
            };

            return shelfVm;
        }
    }
}
