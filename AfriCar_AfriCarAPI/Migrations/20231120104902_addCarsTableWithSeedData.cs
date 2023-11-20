using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AfriCar_AfriCarAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCarsTableWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    ReleaseYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Classification", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "ReleaseYear", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Sedan", new DateTime(2023, 11, 20, 12, 49, 2, 339, DateTimeKind.Local).AddTicks(6127), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/hxsu50sgmt5onrl3p1p8.jpg", "Toyota Corolla", 4, 200.0, "2018", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "SUV", new DateTime(2023, 11, 20, 12, 49, 2, 339, DateTimeKind.Local).AddTicks(6139), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/sopj1bycevitusiddh0n.jpg", "Ford Explorer", 4, 500.0, "2019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Convertible", new DateTime(2023, 11, 20, 12, 49, 2, 339, DateTimeKind.Local).AddTicks(6141), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/zq2f27omunuan1lba1tg.jpg", "Ford Mustang", 2, 200.0, "2019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Sedan", new DateTime(2023, 11, 20, 12, 49, 2, 339, DateTimeKind.Local).AddTicks(6143), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/l5zxmoivfspke86qmu9b.jpg", "Chrysler 300", 4, 300.0, "2014", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Sedan", new DateTime(2023, 11, 20, 12, 49, 2, 339, DateTimeKind.Local).AddTicks(6145), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/nhobn79bdvgoasgwtxvt.jpg", "Volkswagen Jetta", 4, 290.0, "2017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
