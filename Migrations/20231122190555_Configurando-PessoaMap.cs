using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoPessoaMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCnpj",
                table: "TBPESSOA",
                column: "PesCnpj",
                unique: true,
                filter: "[PesCnpj] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCnpj",
                table: "TBPESSOA");
        }
    }
}
