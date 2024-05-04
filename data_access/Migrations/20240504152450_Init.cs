using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Credentials_Id",
                        column: x => x.Id,
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Count_Pages = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Publication_Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsContinuation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer", x => new { x.BooksId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_BookCustomer_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthdate", "Last_Name", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1885, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shevchenko", "Taras", "Grigorovuch" },
                    { 2, new DateTime(1856, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Franko", "Ivan", "Jakovlevich" },
                    { 3, new DateTime(1871, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukrainka", "Lesia", "Petrivna" }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "CustomerId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "mirada", "password" },
                    { 2, null, "user", "user" },
                    { 3, null, "admin", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The main genre of short narrative prose", "Novella" },
                    { 2, "A prose genre that, in terms of text volume, occupies an intermediate place between a novel and a story", "Short novell" },
                    { 3, "A literary genre, often prose, that originated in the Middle Ages among the Romance peoples", "Roman" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Rivne st.Soborna 101", "Ababagalamaga" },
                    { 2, "Kyiv st.Kyivska 25", "Avers" },
                    { 3, "Kostopil st.Rivnenka 107", "ACCA" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Count_Pages", "GenreId", "IsContinuation", "Name", "Price", "Publication_Year", "PublisherId", "Sale_Price" },
                values: new object[,]
                {
                    { 1, 1, 672, 1, false, "Kobzar", 500m, new DateTime(2010, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 650m },
                    { 2, 1, 170, 2, false, "Haidamaki", 300m, new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 350m },
                    { 3, 2, 224, 3, false, "Zahar Berkut", 185m, new DateTime(2012, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 220m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "FullName" },
                values: new object[,]
                {
                    { 1, "Lviv st.Lykasha 5", "Kostopil", "Labenskyi Vitalii Valeriyovuch" },
                    { 2, "Kostopil st.Zaricha 18/1", "Kostopil", "Snitczuk Muroslava Oleksandrivna" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_CustomersId",
                table: "BookCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Credentials");
        }
    }
}
