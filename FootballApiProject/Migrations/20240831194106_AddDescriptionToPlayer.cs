using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teams",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stadiums",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Players",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Leagues",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "Description",
                value: "The top level of the English football league system.");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 2,
                column: "Description",
                value: "The men's top professional football division of the Spanish football league system.");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 3,
                column: "Description",
                value: "A professional association football league in Germany.");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 4,
                column: "Description",
                value: "A professional league competition for football clubs located at the top of the Italian football league system.");

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 5,
                column: "Description",
                value: "The French professional league for men's association football clubs.");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 30, 21, 41, 5, 709, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 31, 21, 41, 5, 709, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 1, 21, 41, 5, 709, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePublished",
                value: new DateTime(2024, 8, 26, 21, 41, 5, 709, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "NewsItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePublished",
                value: new DateTime(2024, 8, 29, 21, 41, 5, 709, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "Description",
                value: "A world-class goalkeeper known for his incredible reflexes.");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "Description",
                value: "Considered one of the greatest football players of all time.");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "Description",
                value: "A prolific goal scorer and one of the best forwards in the world.");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4,
                column: "Description",
                value: "Known for his incredible skills and larger-than-life personality.");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5,
                column: "Description",
                value: "A young, explosive forward with a bright future ahead.");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 1,
                column: "Description",
                value: "The home of Manchester United, known as 'The Theatre of Dreams'.");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 2,
                column: "Description",
                value: "The home of FC Barcelona, the largest stadium in Spain and Europe.");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 3,
                column: "Description",
                value: "A football stadium in Munich with a unique exterior design.");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 4,
                column: "Description",
                value: "One of the most iconic stadiums in Italy, home to AC Milan.");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 5,
                column: "Description",
                value: "The home of Paris Saint-Germain, located in Paris.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "Description",
                value: "One of the most successful clubs in English football.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "Description",
                value: "A dominant force in Spanish and European football.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "Description",
                value: "The most successful football club in Germany.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4,
                column: "Description",
                value: "One of the most successful football clubs in Italy.");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5,
                column: "Description",
                value: "A dominant club in French football with numerous titles.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Leagues");

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
    }
}
