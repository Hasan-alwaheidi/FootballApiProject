using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerProfilePicturePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 28, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 29, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 30, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 8, 24, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublished",
                value: new DateTime(2024, 8, 27, 12, 38, 29, 721, DateTimeKind.Local).AddTicks(9705));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 28, 0, 6, 25, 106, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 29, 0, 6, 25, 106, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 30, 0, 6, 25, 106, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 8, 24, 0, 6, 25, 106, DateTimeKind.Local).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublished",
                value: new DateTime(2024, 8, 27, 0, 6, 25, 106, DateTimeKind.Local).AddTicks(8618));
        }
    }
}
