using Microsoft.EntityFrameworkCore.Migrations;

namespace AXA.Exam.API.Migrations
{
    public partial class initApplicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PositionApplied = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Source = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    XAxaApiKey = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
