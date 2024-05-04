﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access;

#nullable disable

namespace data_access.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20240504152450_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookCustomer", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "CustomersId");

                    b.HasIndex("CustomersId");

                    b.ToTable("BookCustomer");
                });

            modelBuilder.Entity("data_access.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1885, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Name = "Shevchenko",
                            Name = "Taras",
                            Surname = "Grigorovuch"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1856, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Name = "Franko",
                            Name = "Ivan",
                            Surname = "Jakovlevich"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1871, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Name = "Ukrainka",
                            Name = "Lesia",
                            Surname = "Petrivna"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Count_Pages")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool>("IsContinuation")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Publication_Year")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sale_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Count_Pages = 672,
                            GenreId = 1,
                            IsContinuation = false,
                            Name = "Kobzar",
                            Price = 500m,
                            Publication_Year = new DateTime(2010, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Sale_Price = 650m
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Count_Pages = 170,
                            GenreId = 2,
                            IsContinuation = false,
                            Name = "Haidamaki",
                            Price = 300m,
                            Publication_Year = new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            Sale_Price = 350m
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Count_Pages = 224,
                            GenreId = 3,
                            IsContinuation = false,
                            Name = "Zahar Berkut",
                            Price = 185m,
                            Publication_Year = new DateTime(2012, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Sale_Price = 220m
                        });
                });

            modelBuilder.Entity("data_access.Entities.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "mirada",
                            Password = "password"
                        },
                        new
                        {
                            Id = 2,
                            Login = "user",
                            Password = "user"
                        },
                        new
                        {
                            Id = 3,
                            Login = "admin",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Lviv st.Lykasha 5",
                            City = "Kostopil",
                            FullName = "Labenskyi Vitalii Valeriyovuch"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kostopil st.Zaricha 18/1",
                            City = "Kostopil",
                            FullName = "Snitczuk Muroslava Oleksandrivna"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The main genre of short narrative prose",
                            Name = "Novella"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A prose genre that, in terms of text volume, occupies an intermediate place between a novel and a story",
                            Name = "Short novell"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A literary genre, often prose, that originated in the Middle Ages among the Romance peoples",
                            Name = "Roman"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rivne st.Soborna 101",
                            Name = "Ababagalamaga"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kyiv st.Kyivska 25",
                            Name = "Avers"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Kostopil st.Rivnenka 107",
                            Name = "ACCA"
                        });
                });

            modelBuilder.Entity("BookCustomer", b =>
                {
                    b.HasOne("data_access.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("data_access.Entities.Book", b =>
                {
                    b.HasOne("data_access.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("data_access.Entities.Customer", b =>
                {
                    b.HasOne("data_access.Entities.Credential", "Credential")
                        .WithOne("Customer")
                        .HasForeignKey("data_access.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("data_access.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("data_access.Entities.Credential", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });

            modelBuilder.Entity("data_access.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("data_access.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
