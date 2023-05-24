using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;

namespace BookCrossing.Application.ViewModels.ShelfViewModels
{
    public class ShelfViewModel
    {
        public int? Id { get; set; }
        public string ShelfName { get; set; }
        public string ShelfImagePath { get; set; }
        public string Adress { get; set; }

        public ShelfViewModel(Shelf shelf)
        {
            Id = shelf.Id;
            ShelfName = shelf.ShelfName;
            ShelfImagePath = shelf.ShelfImagePath;
            Adress = shelf.Adress;
        }
    }
}
