using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class fix_casc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "Alias",
                value: "Kenta kofot");

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "Alias",
                value: "SlayerKiller69");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Games_GameId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_Kills_Players_KillerId",
                table: "Kills");

            migrationBuilder.DropForeignKey(
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Players");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

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
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
