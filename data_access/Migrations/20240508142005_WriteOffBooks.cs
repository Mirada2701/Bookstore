using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class WriteOffBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_WriteOffBooks_WriteOffBooksId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_WriteOffBooksId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "WriteOffBooksId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CustomerWriteOffBooks",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    WriteOffBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWriteOffBooks", x => new { x.CustomersId, x.WriteOffBooksId });
                    table.ForeignKey(
                        name: "FK_CustomerWriteOffBooks_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerWriteOffBooks_WriteOffBooks_WriteOffBooksId",
                        column: x => x.WriteOffBooksId,
                        principalTable: "WriteOffBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWriteOffBooks_WriteOffBooksId",
                table: "CustomerWriteOffBooks",
                column: "WriteOffBooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerWriteOffBooks");

            migrationBuilder.AddColumn<int>(
                name: "WriteOffBooksId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "WriteOffBooksId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "WriteOffBooksId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_WriteOffBooksId",
                table: "Customers",
                column: "WriteOffBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_WriteOffBooks_WriteOffBooksId",
                table: "Customers",
                column: "WriteOffBooksId",
                principalTable: "WriteOffBooks",
                principalColumn: "Id");
        }
    }
}
