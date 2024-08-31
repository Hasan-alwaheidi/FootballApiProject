using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class MakeScoreAndeResultNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "Matches",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 22, 10, 28, 45, 388, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 23, 10, 28, 45, 388, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 24, 10, 28, 45, 388, DateTimeKind.Local).AddTicks(4729));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "Matches",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

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
    }
}
