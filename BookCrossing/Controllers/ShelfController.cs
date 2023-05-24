using BookCrossing.Application.Interfaces;
using BookCrossing.Application.ViewModels.BookViewModels;
using BookCrossing.Application.ViewModels.ShelfViewModels;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly IShelfService _shelfService;
        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        [HttpGet("GetShelves")]
        public async Task<IList<ShelfViewModel>> GetShelves()
        {
            var shelvesVm = await _shelfService.GetShelves();
            return shelvesVm;
        }

        [HttpPost("AddShelf")]
        public async Task<IActionResult> AddShelf(ShelfForCreationViewModel shelf)
        {
            await _shelfService.AddShelfAsync(shelf);

            return Ok();
        }

        [HttpGet("ShelfById/{id}")]
        public async Task<ShelfViewModel> GetShelfByIdAsync(int id)
        {
            var shelf = await _shelfService.GetShelfByIdAsync(id);

            return shelf;
        }
    }
}
