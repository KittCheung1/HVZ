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
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats",
                column: "PlayerId",
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
                name: "FK_SquadMembers_Players_PlayerId",
                table: "SquadMembers");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Players_PlayerId",
                table: "Chats",
                column: "PlayerId",
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
