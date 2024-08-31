using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class MakeScoreAndResultNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 22, 1, 42, 17, 200, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 23, 1, 42, 17, 200, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 24, 1, 42, 17, 200, DateTimeKind.Local).AddTicks(9154));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 21, 13, 42, 31, 361, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 22, 13, 42, 31, 361, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 23, 13, 42, 31, 361, DateTimeKind.Local).AddTicks(9314));
        }
    }
}
