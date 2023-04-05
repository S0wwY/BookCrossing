
using BookCrossing.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCrossing.Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
