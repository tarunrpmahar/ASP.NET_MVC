using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Books> tbl_Books { get; set; }

        public DbSet<BookGallery> tbl_BookGallery { get; set; }
        public DbSet<Language> tbl_Lang { get; set; }
    }
}
