using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoIndexUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuLogin",
                table: "TBUSUARIO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.CreateIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO",
                column: "UsuLogin",
                unique: true,
                filter: "[UsuLogin] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO");

            migrationBuilder.AlterColumn<string>(
                name: "UsuLogin",
                table: "TBUSUARIO",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
