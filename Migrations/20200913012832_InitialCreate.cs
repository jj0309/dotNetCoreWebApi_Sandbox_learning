using Microsoft.EntityFrameworkCore.Migrations;

namespace _dotnetSandBox.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    hitpoints = table.Column<int>(nullable: false),
                    strenght = table.Column<int>(nullable: false),
                    defense = table.Column<int>(nullable: false),
                    intelligence = table.Column<int>(nullable: false),
                    playClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
