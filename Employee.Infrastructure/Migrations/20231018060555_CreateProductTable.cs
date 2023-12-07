using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellPrice = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 794, DateTimeKind.Unspecified).AddTicks(1266), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 794, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BarCode", "CountryId", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Price", "ProductName", "Rating", "SellPrice", "Status" },
                values: new object[] { 1, "bashar", 1, new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 795, DateTimeKind.Unspecified).AddTicks(1861), new TimeSpan(0, 6, 0, 0, 0)), "1", "Brand New Model", new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 795, DateTimeKind.Unspecified).AddTicks(1901), new TimeSpan(0, 6, 0, 0, 0)), null, 50000.0, "Laptop", 4.5, 52000.0, 1 });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 796, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 18, 12, 5, 54, 796, DateTimeKind.Unspecified).AddTicks(1301), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 18, 11, 42, 37, 294, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 18, 11, 42, 37, 294, DateTimeKind.Unspecified).AddTicks(543), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "State",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 10, 18, 11, 42, 37, 295, DateTimeKind.Unspecified).AddTicks(355), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 10, 18, 11, 42, 37, 295, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
