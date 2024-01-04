using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfriCar_AfriCarAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "CarNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 23, 0, 412, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.CreateIndex(
                name: "IX_CarNumbers_CarID",
                table: "CarNumbers",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarNumbers_Cars_CarID",
                table: "CarNumbers",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarNumbers_Cars_CarID",
                table: "CarNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CarNumbers_CarID",
                table: "CarNumbers");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "CarNumbers");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 12, 43, 17, 93, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 12, 43, 17, 93, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 12, 43, 17, 93, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 12, 43, 17, 93, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 12, 43, 17, 93, DateTimeKind.Local).AddTicks(1352));
        }
    }
}
