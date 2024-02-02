using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuide.Server.Migrations
{
    /// <inheritdoc />
    public partial class SuggestionsAddedSendEmailbool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendEmail",
                table: "Suggestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d6eff21-12dd-40eb-8828-39e241466c64", "AQAAAAIAAYagAAAAEP8YuypQLmiRWaYlde9mCn0kkdv17859rtAFSModwh0z5esJybHu53Vy/LGzTVFE2A==", "f3467e1c-c907-4047-8029-5e1266c95f72" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 31, 19, 15, 23, 977, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 31, 19, 15, 23, 977, DateTimeKind.Local).AddTicks(5765));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendEmail",
                table: "Suggestions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cf0fb28-d133-40c8-a918-320911f1a7f4", "AQAAAAIAAYagAAAAEO6XlJ56/E7jiHUvqnPAXVZp84U2ZWnFmh0zv/w03pRDG4MIoAOT3WImEzkXYZCDPw==", "cbd48d07-33b7-4118-86a7-f961ff1cd034" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 31, 18, 21, 51, 723, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 31, 18, 21, 51, 723, DateTimeKind.Local).AddTicks(8848));
        }
    }
}
