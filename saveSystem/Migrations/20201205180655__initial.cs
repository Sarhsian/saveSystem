using Microsoft.EntityFrameworkCore.Migrations;

namespace saveSystem.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<int>(type: "int", nullable: false),
                    SubjectFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Course", "SubjectFileName", "SubjectName", "isFavorite" },
                values: new object[] { 1, 1, "lol.pdf", "lol", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
