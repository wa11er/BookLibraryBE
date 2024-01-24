using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookLibraryBE.Models;

namespace BookLibraryBE.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

    }
}