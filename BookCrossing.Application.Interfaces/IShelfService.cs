using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.ShelfViewModels;
using BookCrossing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookCrossing.Application.Interfaces
{
    public interface IShelfService
    {
        Task AddShelfAsync(ShelfForCreationViewModel shelf);
        Task DeleteShelfByIdAsync(int shelfId);
        Task<ShelfViewModel> GetShelfByIdAsync(int shelfId);
        Task<IList<ShelfViewModel>> GetShelves();

    }
}
