using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApiProject.Migrations
{
    /// <inheritdoc />
    public partial class AddStadiumTeamsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Stadiums");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 16, 22, 23, 57, 815, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 17, 22, 23, 57, 815, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 18, 22, 23, 57, 815, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/stadiums/old_trafford.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 2,
                column: "ImagePath",
                value: "/images/stadiums/camp_nou.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 3,
                column: "ImagePath",
                value: "/images/stadiums/allianz_arena.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 4,
                column: "ImagePath",
                value: "/images/stadiums/san_siro.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 5,
                column: "ImagePath",
                value: "/images/stadiums/parc_des_princes.jpg");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Stadiums");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Stadiums",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 16, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 17, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 8, 18, 18, 37, 4, 811, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 1,
                column: "PicturePath",
                value: "/images/stadiums/old_trafford.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 2,
                column: "PicturePath",
                value: "/images/stadiums/camp_nou.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 3,
                column: "PicturePath",
                value: "/images/stadiums/allianz_arena.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 4,
                column: "PicturePath",
                value: "/images/stadiums/san_siro.jpg");

            migrationBuilder.UpdateData(
                table: "Stadiums",
                keyColumn: "StadiumId",
                keyValue: 5,
                column: "PicturePath",
                value: "/images/stadiums/parc_des_princes.jpg");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stadiums_StadiumId",
                table: "Teams",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "StadiumId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
