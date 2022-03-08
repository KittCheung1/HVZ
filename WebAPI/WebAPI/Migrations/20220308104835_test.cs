using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kill_Games_GameId",
                table: "Kill");

            migrationBuilder.DropForeignKey(
                name: "FK_Kill_Players_KillerId",
                table: "Kill");

            migrationBuilder.DropForeignKey(
                name: "FK_Kill_Players_VictimId",
                table: "Kill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kill",
                table: "Kill");

            migrationBuilder.RenameTable(
                name: "Kill",
                newName: "Kills");

            migrationBuilder.RenameIndex(
                name: "IX_Kill_VictimId",
                table: "Kills",
                newName: "IX_Kills_VictimId");

            migrationBuilder.RenameIndex(
                name: "IX_Kill_KillerId",
                table: "Kills",
                newName: "IX_Kills_KillerId");

            migrationBuilder.RenameIndex(
                name: "IX_Kill_GameId",
                table: "Kills",
                newName: "IX_Kills_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kills",
                table: "Kills",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Kills_Players_VictimId",
                table: "Kills",
                column: "VictimId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_VictimId",
                table: "Kills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kills",
                table: "Kills");

            migrationBuilder.RenameTable(
                name: "Kills",
                newName: "Kill");

            migrationBuilder.RenameIndex(
                name: "IX_Kills_VictimId",
                table: "Kill",
                newName: "IX_Kill_VictimId");

            migrationBuilder.RenameIndex(
                name: "IX_Kills_KillerId",
                table: "Kill",
                newName: "IX_Kill_KillerId");

            migrationBuilder.RenameIndex(
                name: "IX_Kills_GameId",
                table: "Kill",
                newName: "IX_Kill_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kill",
                table: "Kill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kill_Games_GameId",
                table: "Kill",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kill_Players_KillerId",
                table: "Kill",
                column: "KillerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kill_Players_VictimId",
                table: "Kill",
                column: "VictimId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
