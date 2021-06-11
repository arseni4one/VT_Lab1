using Microsoft.EntityFrameworkCore.Migrations;

namespace VT_Lab1.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TileGroups",
                columns: table => new
                {
                    TileGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileGroups", x => x.TileGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Tilees",
                columns: table => new
                {
                    TileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TileGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilees", x => x.TileId);
                    table.ForeignKey(
                        name: "FK_Tilees_TileGroups_TileGroupId",
                        column: x => x.TileGroupId,
                        principalTable: "TileGroups",
                        principalColumn: "TileGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tilees_TileGroupId",
                table: "Tilees",
                column: "TileGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tilees");

            migrationBuilder.DropTable(
                name: "TileGroups");
        }
    }
}
