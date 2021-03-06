using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class initial : Migration
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
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Human_Visible = table.Column<bool>(type: "bit", nullable: false),
                    Is_Zombie_Visible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHuman = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squads_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Is_Human = table.Column<bool>(type: "bit", nullable: false),
                    Is_Patient_Zero = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Human_Global = table.Column<bool>(type: "bit", nullable: false),
                    Is_Zombie_Global = table.Column<bool>(type: "bit", nullable: false),
                    Chat_Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kills",
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
                    table.PrimaryKey("PK_Kills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kills_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_Players_KillerId",
                        column: x => x.KillerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kills_Players_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SquadMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadMembers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadMembers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadMembers_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SquadCheckIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false),
                    SquadmemberId = table.Column<int>(type: "int", nullable: false),
                    Start_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadCheckIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadCheckIns_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadCheckIns_SquadMembers_SquadmemberId",
                        column: x => x.SquadmemberId,
                        principalTable: "SquadMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadCheckIns_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
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
                table: "Missions",
                columns: new[] { "Id", "Description", "End_time", "GameId", "Is_Human_Visible", "Is_Zombie_Visible", "Name", "Start_time" },
                values: new object[] { 1, "Shop energy drinks at coop", null, 1, false, true, "Secret Coop mission", null });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Bite_Code", "GameId", "Is_Human", "Is_Patient_Zero", "UserId" },
                values: new object[,]
                {
                    { 1, "JagBetDig434", 1, true, false, 1 },
                    { 2, "JagBetDig123", 1, false, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Squads",
                columns: new[] { "Id", "GameID", "IsHuman", "Name" },
                values: new object[] { 1, 1, true, "Mega-squad" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Chat_Time", "GameId", "Is_Human_Global", "Is_Zombie_Global", "Message", "PlayerId", "SquadId" },
                values: new object[] { 1, "13:04", 1, true, false, "Im the best, u scrubz", 2, 1 });

            migrationBuilder.InsertData(
                table: "Kills",
                columns: new[] { "Id", "GameId", "KillerId", "Lat", "Lng", "Story", "Time_Of_Death", "VictimId" },
                values: new object[] { 1, 1, 1, null, null, null, "10:33", 2 });

            migrationBuilder.InsertData(
                table: "SquadMembers",
                columns: new[] { "Id", "GameId", "PlayerId", "Rank", "SquadId" },
                values: new object[] { 1, 1, 2, "Generals", 1 });

            migrationBuilder.InsertData(
                table: "SquadCheckIns",
                columns: new[] { "Id", "End_Time", "GameId", "Lat", "Lng", "SquadId", "SquadmemberId", "Start_Time" },
                values: new object[] { 1, "14:20", 1, 41.231299999999997, 2.21312, 1, 1, "13:37" });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_GameId",
                table: "Chats",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_PlayerId",
                table: "Chats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SquadId",
                table: "Chats",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_GameId",
                table: "Kills",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_KillerId",
                table: "Kills",
                column: "KillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_VictimId",
                table: "Kills",
                column: "VictimId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_GameId",
                table: "Missions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckIns_GameId",
                table: "SquadCheckIns",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckIns_SquadId",
                table: "SquadCheckIns",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadCheckIns_SquadmemberId",
                table: "SquadCheckIns",
                column: "SquadmemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadMembers_GameId",
                table: "SquadMembers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadMembers_PlayerId",
                table: "SquadMembers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadMembers_SquadId",
                table: "SquadMembers",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_GameID",
                table: "Squads",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Kills");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "SquadCheckIns");

            migrationBuilder.DropTable(
                name: "SquadMembers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
