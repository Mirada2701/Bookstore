using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author()
                {
                    Id = 1,
                    Name = "Taras",
                    Last_Name = "Shevchenko",
                    Surname = "Grigorovuch",
                    Birthdate = new DateTime(1885,2,3)
                },
                new Author()
                {
                    Id = 2,
                    Name = "Ivan",
                    Last_Name = "Franko",
                    Surname = "Jakovlevich",
                    Birthdate = new DateTime(1856,5,28)
                },
                new Author()
                {
                    Id = 3,
                    Name = "Lesia",
                    Last_Name = "Ukrainka",
                    Surname = "Petrivna",
                    Birthdate = new DateTime(1871,2,25)
                }
            });
        }
        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher()
                {
                    Id = 1,
                    Name = "Ababagalamaga",
                    Address = "Rivne st.Soborna 101"
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "Avers",
                    Address = "Kyiv st.Kyivska 25"
                },
                new Publisher()
                {
                    Id = 3,
                    Name = "ACCA",
                    Address = "Kostopil st.Rivnenka 107"
                }
            });
        }
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Novella",
                    Description = "The main genre of short narrative prose"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Short novell",
                    Description = "A prose genre that, in terms of text volume, occupies an intermediate place between a novel and a story"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Roman",
                    Description = "A literary genre, often prose, that originated in the Middle Ages among the Romance peoples"
                }
            });
        }
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book()
                {
                    Id = 1,
                    Name = "Kobzar",
                    AuthorId = 1,
                    PublisherId = 1,
                    Count_Pages = 672,
                    GenreId = 1,
                    Publication_Year = new DateTime(2010,4,5),
                    Price = 500,
                    Sale_Price = 650,
                    IsContinuation = false
                },
               new Book()
                {
                    Id = 2,
                    Name = "Haidamaki",
                    AuthorId = 1,
                    PublisherId = 2,
                    Count_Pages = 170,
                    GenreId = 2,
                    Publication_Year = new DateTime(2002,5,9),
                    Price = 300,
                    Sale_Price = 350,
                    IsContinuation = false
                },
               new Book()
                {
                    Id = 3,
                    Name = "Zahar Berkut",
                    AuthorId = 2,
                    PublisherId = 3,
                    Count_Pages = 224,
                    GenreId = 3,
                    Publication_Year = new DateTime(2012,1,9),
                    Price = 185,
                    Sale_Price = 220,
                    IsContinuation = false
                }
            });
        }
        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer()
                {
                    Id = 1,
                    FullName = "Labenskyi Vitalii Valeriyovuch",
                    Address = "Lviv st.Lykasha 5",
                    City = "Kostopil"
                },
               new Customer()
                {
                    Id = 2,
                    FullName = "Snitczuk Muroslava Oleksandrivna",
                    Address = "Kostopil st.Zaricha 18/1",
                    City = "Kostopil"
                }               
            });
        }
        public static void SeedCredentials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>().HasData(new Credential[]
            {
                new Credential()
                {
                    Id = 1,
                    Login = "mirada",
                    Password = "password"
                },
               new Credential()
                {
                    Id = 2,
                    Login = "user",
                    Password = "user"
                },
               new Credential()
                {
                    Id = 3,
                    Login = "admin",
                    Password = "1234"
                }
            });
        }
    }
}
