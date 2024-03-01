using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfriCar_AfriCarAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedDetailsToTransmissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Cars",
                newName: "TransmissionType");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 15, 14, 50, 896, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 15, 14, 50, 896, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 15, 14, 50, 896, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 15, 14, 50, 896, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 15, 14, 50, 896, DateTimeKind.Local).AddTicks(6102));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransmissionType",
                table: "Cars",
                newName: "Details");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 14, 59, 43, 744, DateTimeKind.Local).AddTicks(1119));
        }
    }
}
