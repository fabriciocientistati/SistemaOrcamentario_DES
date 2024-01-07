using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class correçãoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA");

            migrationBuilder.AlterColumn<string>(
                name: "PesCpf",
                table: "TBPESSOA",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA",
                column: "PesCpf",
                unique: true,
                filter: "[PesCpf] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA");

            migrationBuilder.AlterColumn<string>(
                name: "PesCpf",
                table: "TBPESSOA",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA",
                column: "PesCpf",
                unique: true);
        }
    }
}
