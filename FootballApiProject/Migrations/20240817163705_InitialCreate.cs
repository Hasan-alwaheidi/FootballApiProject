using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Season = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Coach = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Result = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "Country", "LogoPath", "Name", "Season" },
                values: new object[,]
                {
                    { 1, "England", "/images/default.jpg", "Premier League", "2023/2024" },
                    { 2, "Spain", "/images/default.jpg", "La Liga", "2023/2024" },
                    { 3, "Germany", "/images/default.jpg", "Bundesliga", "2023/2024" },
                    { 4, "Italy", "/images/default.jpg", "Serie A", "2023/2024" },
                    { 5, "France", "/images/default.jpg", "Ligue 1", "2023/2024" }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "StadiumId", "Capacity", "Location", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, 76000, "Manchester, England", "Old Trafford", "/images/stadiums/old_trafford.jpg" },
                    { 2, 99354, "Barcelona, Spain", "Camp Nou", "/images/stadiums/camp_nou.jpg" },
                    { 3, 75000, "Munich, Germany", "Allianz Arena", "/images/stadiums/allianz_arena.jpg" },
                    { 4, 80000, "Milan, Italy", "San Siro", "/images/stadiums/san_siro.jpg" },
                    { 5, 47929, "Paris, France", "Parc des Princes", "/images/stadiums/parc_des_princes.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Coach", "LeagueId", "LogoPath", "Name", "StadiumId" },
                values: new object[,]
                {
                    { 1, "Erik ten Hag", 1, "/images/default.jpg", "Manchester United", 1 },
                    { 2, "Xavi Hernandez", 2, "/images/default.jpg", "Barcelona", 2 },
                    { 3, "Julian Nagelsmann", 3, "/images/default.jpg", "Bayern Munich", 3 },
                    { 4, "Stefano Pioli", 4, "/images/default.jpg", "AC Milan", 4 },
                    { 5, "Mauricio Pochettino", 5, "/images/default.jpg", "Paris Saint-Germain", 5 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayTeamId", "Date", "HomeTeamId", "Result", "Score" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 8, 16, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5080), 1, 0, "2-1" },
                    { 2, 4, new DateTime(2024, 8, 17, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5145), 3, 2, "1-1" },
                    { 3, 1, new DateTime(2024, 8, 18, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5148), 5, null, "" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Name", "Nationality", "Position", "ProfilePicturePath", "TeamId" },
                values: new object[,]
                {
                    { 1, "David de Gea", "Spanish", 0, "/images/playerAvatar.jpg", 1 },
                    { 2, "Lionel Messi", "Argentinian", 3, "/images/playerAvatar.jpg", 2 },
                    { 3, "Robert Lewandowski", "Polish", 3, "/images/playerAvatar.jpg", 3 },
                    { 4, "Zlatan Ibrahimovic", "Swedish", 3, "/images/playerAvatar.jpg", 4 },
                    { 5, "Kylian Mbappe", "French", 3, "/images/playerAvatar.jpg", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
