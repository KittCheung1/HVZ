using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class fix_casc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills",
                column: "KillerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills",
                column: "KillerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
