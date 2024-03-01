using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfriCar_AfriCarAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedDateValuesOnSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1103), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1114), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1115), new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1117), new DateTime(2014, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1119), new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 53, 37, 46, DateTimeKind.Local).AddTicks(5480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 53, 37, 46, DateTimeKind.Local).AddTicks(5490), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 53, 37, 46, DateTimeKind.Local).AddTicks(5492), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 53, 37, 46, DateTimeKind.Local).AddTicks(5494), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ReleaseYear" },
                values: new object[] { new DateTime(2024, 3, 1, 14, 53, 37, 46, DateTimeKind.Local).AddTicks(5495), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017) });
        }
    }
}
