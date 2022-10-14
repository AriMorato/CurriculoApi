using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculoApi.Migrations
{
    public partial class CampoCurriculoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Curriculo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StatusCurriculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalheStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCurriculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.DropTable(
                name: "StatusCurriculo");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Curriculo");
        }
    }
}
