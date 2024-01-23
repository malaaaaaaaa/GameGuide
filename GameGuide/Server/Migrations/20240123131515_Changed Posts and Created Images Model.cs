using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuide.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPostsandCreatedImagesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Posts",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5de1603-a265-4918-acdf-4d848723f8ac", "AQAAAAIAAYagAAAAENJBXnukVMT4o6qk+Lyh7MJ9gk+usyY5rFG4LRTTjlW02CGLlu0a8IfmIy852/l8TA==", "c7fc40e7-8d61-46d2-b871-00ee0c5cfe5d" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 23, 21, 15, 15, 115, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 23, 21, 15, 15, 115, DateTimeKind.Local).AddTicks(329));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "imageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0375de9c-a386-4e66-993e-428fcaa52ab7", "AQAAAAIAAYagAAAAEL2hsEQu2J9i0hWIFNOLpg3ba3R29OHvI7Gvsw4o49OLKfsixYiSJ/GIsRvwCcpBYg==", "77160374-152a-42a4-ac8b-2141c5646b4b" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 23, 20, 44, 52, 508, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 1, 23, 20, 44, 52, 508, DateTimeKind.Local).AddTicks(7870));
        }
    }
}
