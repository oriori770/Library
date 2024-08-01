using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Library.Models.Bookcase> Bookcase { get; set; } = default!;
        public DbSet<Library.Models.Shelf> Shelf { get; set; } = default!;
        public DbSet<Library.Models.Book> Book { get; set; } = default!;
        public DbSet<Library.Models.SetBooks> SetBooks { get; set; } = default!;
    }
}
