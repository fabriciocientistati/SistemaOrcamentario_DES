using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class correcaoentidadeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuAltPor",
                table: "TBUSUARIO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuIncPor",
                table: "TBUSUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuAltPor",
                table: "TBUSUARIO");

            migrationBuilder.DropColumn(
                name: "UsuIncPor",
                table: "TBUSUARIO");
        }
    }
}
