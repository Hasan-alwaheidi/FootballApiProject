using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItems", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 26, 19, 22, 33, 714, DateTimeKind.Local).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 27, 19, 22, 33, 714, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 28, 19, 22, 33, 714, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.InsertData(
                table: "NewsItems",
                columns: new[] { "Id", "Content", "DatePublished", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, "Manchester United has signed a new forward.", new DateTime(2024, 8, 22, 19, 22, 33, 714, DateTimeKind.Local).AddTicks(2156), "/newsimages/news1.jpg", "New Signing for Manchester United" },
                    { 2, "Barcelona won the Champions League quarterfinals.", new DateTime(2024, 8, 25, 19, 22, 33, 714, DateTimeKind.Local).AddTicks(2162), "/newsimages/news2.jpg", "Champions League Results" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsItems");

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
    }
}
