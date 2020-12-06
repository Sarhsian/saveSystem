using Microsoft.EntityFrameworkCore.Migrations;

namespace saveSystem.Migrations
{
    public partial class initial3loc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectFileLocation",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectFileLocation",
                table: "Subjects");
        }
    }
}
