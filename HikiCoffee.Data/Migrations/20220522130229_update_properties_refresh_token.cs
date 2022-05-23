using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiCoffee.Data.Migrations
{
    public partial class update_properties_refresh_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AppUsers",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                column: "ConcurrencyStamp",
                value: "64a93893-0b27-4b28-8a0d-4a72970ab96b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                column: "ConcurrencyStamp",
                value: "c18b3347-05cd-4df2-81d2-08c4d20c461d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                column: "ConcurrencyStamp",
                value: "f5d92650-c1cd-4916-a3c7-8343c6cd7e63");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0985994-3014-4c88-bb5e-b4867743eb9c", "AQAAAAEAACcQAAAAELppbh3y6xf51L97x0CUmXHBn7Xife20F0D0g6zamoDGO7CYxKMLiyinIfPxv5gk6A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                column: "ConcurrencyStamp",
                value: "9b0281a8-e80d-4f51-aacf-5f058ef016a4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                column: "ConcurrencyStamp",
                value: "a0980e26-d652-465e-85ee-a85cee6cfff0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                column: "ConcurrencyStamp",
                value: "cdfc141e-8d76-416e-b19d-ef8ee4e90386");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7bc5d03e-0838-4deb-a385-ab1b48368b11", "AQAAAAEAACcQAAAAEFtTf7SuC4F1KeMoUZcoOoxN8XgOfZGl5qzFSk0NWJWJirqzSSIxW6unbWPPL5Iz7g==" });
        }
    }
}
