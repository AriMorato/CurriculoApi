using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculoApi.Migrations
{
    public partial class TBStatusCurriculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "StatusCurriculo",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  DetalheStatus = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_StatusCurriculo", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
