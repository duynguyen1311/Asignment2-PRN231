using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookAuthor>()
                .HasKey(p => new { p.book_id, p.author_id });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Author)
                .WithMany(p => p.BookAuthor)
                .HasForeignKey(p => p.author_id);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Book)
                .WithMany(p => p.BookAuthor)
                .HasForeignKey(p => p.book_id);
        }
    }
}
