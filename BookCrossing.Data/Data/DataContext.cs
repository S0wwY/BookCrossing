using BookCrossing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<BookShelf> BookShelves { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<UserBookHistory> UserBooks { get; set; }
        //public DbSet<BookSubscription> BookSubscriptions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           Database.EnsureCreated();
        }
    }
}
