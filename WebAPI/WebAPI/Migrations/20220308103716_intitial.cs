using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Game_state = table.Column<int>(type: "int", nullable: false),
                    Nw_lat = table.Column<double>(type: "float", nullable: true),
                    Nw_lng = table.Column<double>(type: "float", nullable: true),
                    Se_lat = table.Column<double>(type: "float", nullable: true),
                    Se_lng = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Is_Human = table.Column<int>(type: "int", nullable: false),
                    Is_Patient_Zero = table.Column<int>(type: "int", nullable: false),
                    Bite_Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    KillerId = table.Column<int>(type: "int", nullable: false),
                    VictimId = table.Column<int>(type: "int", nullable: false),
                    Time_Of_Death = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kill_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kill_Players_KillerId",
                        column: x => x.KillerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kill_Players_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Game_state", "Name", "Nw_lat", "Nw_lng", "Se_lat", "Se_lng" },
                values: new object[] { 1, 1, "Norrköpings zombie spel", null, null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "First_Name", "Last_Name" },
                values: new object[] { 1, "Martin", "Späck" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "First_Name", "Last_Name" },
                values: new object[] { 2, "Gunvald", "Larsson" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Bite_Code", "GameId", "Is_Human", "Is_Patient_Zero", "UserId" },
                values: new object[] { 1, "JagBetDig123", 1, 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Bite_Code", "GameId", "Is_Human", "Is_Patient_Zero", "UserId" },
                values: new object[] { 2, "JagBetDig123", 1, 0, 1, 2 });

            migrationBuilder.InsertData(
                table: "Kill",
                columns: new[] { "Id", "GameId", "KillerId", "Lat", "Lng", "Story", "Time_Of_Death", "VictimId" },
                values: new object[] { 1, 1, 1, null, null, null, "10:33", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Kill_GameId",
                table: "Kill",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Kill_KillerId",
                table: "Kill",
                column: "KillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kill_VictimId",
                table: "Kill",
                column: "VictimId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kill");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
