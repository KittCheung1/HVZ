using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class initial_games : Migration
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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Game_state", "Name", "Nw_lat", "Nw_lng", "Se_lat", "Se_lng" },
                values: new object[] { 1, 1, "Norrköpings zombie spel", null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
