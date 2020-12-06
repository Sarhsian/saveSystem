using Microsoft.EntityFrameworkCore.Migrations;

namespace saveSystem.Migrations
{
    public partial class addedfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectFileNameDetail",
                table: "Subjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectFileNameDetail",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
