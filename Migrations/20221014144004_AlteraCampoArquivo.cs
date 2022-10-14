using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculoApi.Migrations
{
    public partial class AlteraCampoArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Arquivo",
                table: "Curriculo",
                type: "Text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arquivo",
                table: "Curriculo");
        }
    }
}
