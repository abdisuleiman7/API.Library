using Microsoft.EntityFrameworkCore;
using Template.API.Core.Models;

namespace Template.API.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public LibraryContext()
        {
        }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        } 

    }
}
