using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiCoffee.Data.Migrations
{
    public partial class update_coffee_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeTables_Statuses_StatusId",
                table: "CoffeeTables");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "CoffeeTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                column: "ConcurrencyStamp",
                value: "17651fb6-b1c8-4c91-a5b3-b7643a638d58");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                column: "ConcurrencyStamp",
                value: "0e4cf327-e65f-4740-a788-0ccb7aa1d0e6");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                column: "ConcurrencyStamp",
                value: "202f0aa5-c6fd-4620-b060-772f95756208");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ed4fb94-21e2-4f08-8636-7500e4bb6a04", "AQAAAAEAACcQAAAAEKQEELtYUva6kN1Pqg8B+PwCYH2lUbAfW9ufwlW8jBbCBLscg621FgDCAPfO0yTyjw==" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 45, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 33, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 33, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 33, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 6, 1, 16, 38, 14, 33, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeTables_Statuses_StatusId",
                table: "CoffeeTables",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeTables_Statuses_StatusId",
                table: "CoffeeTables");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "CoffeeTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                column: "ConcurrencyStamp",
                value: "6468d15f-3a06-4603-af53-f7f8f21bfbba");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                column: "ConcurrencyStamp",
                value: "6b5e7a2c-b5c4-4b83-aea6-349187b1b10e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                column: "ConcurrencyStamp",
                value: "1ee11a98-070f-4856-9565-a88093d622d4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48781e00-03ef-44e2-8c47-d3bc3e955a57", "AQAAAAEAACcQAAAAEJ+KwRlk8EZW1JlbvbNj+Rb5SHEMpPg2EAzf0ZYVc0DLD9Yd/vMZ01IHAWQPe9rV8Q==" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 605, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 596, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 596, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 596, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 5, 27, 18, 25, 22, 596, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeTables_Statuses_StatusId",
                table: "CoffeeTables",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
