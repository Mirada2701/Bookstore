using data_access.Entities;
using data_access.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WriteOffBooks> WriteOffBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=LEGION5\SQLEXPRESS;
                                        Initial Catalog = Bookstore;
                                        Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(b => b.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Author>().Property(a => a.Last_Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Author>().Property(a => a.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Publisher>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Publisher>().Property(a => a.Address).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Genre>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Genre>().Property(a => a.Description).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Customer>().Property(a => a.FullName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(a => a.Address).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(a => a.City).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Credential>().Property(a => a.Login).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Credential>().Property(a => a.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<WriteOffBooks>().Property(b => b.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(a => a.Books).HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(a => a.Books).HasForeignKey(b => b.GenreId);
            modelBuilder.Entity<Book>().HasMany(b => b.Customers).WithMany(a => a.Books);
            modelBuilder.Entity<WriteOffBooks>().HasOne(b => b.Author).WithMany(a => a.WriteOffBooks).HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<WriteOffBooks>().HasOne(b => b.Publisher).WithMany(a => a.WriteOffBooks).HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<WriteOffBooks>().HasOne(b => b.Genre).WithMany(a => a.WriteOffBooks).HasForeignKey(b => b.GenreId);
            modelBuilder.Entity<WriteOffBooks>().HasMany(b => b.Customers).WithMany(a => a.WriteOffBooks);
            modelBuilder.Entity<Customer>().HasOne(c => c.Credential)
                .WithOne(c => c.Customer).HasForeignKey<Customer>(c => c.Id);

            modelBuilder.SeedAuthors();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedGenres();
            modelBuilder.SeedBooks();
            modelBuilder.SeedCredentials();
            modelBuilder.SeedCustomers();
        }
    }
}
