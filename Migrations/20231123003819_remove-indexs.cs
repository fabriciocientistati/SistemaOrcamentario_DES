using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class removeindexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCnpj",
                table: "TBPESSOA");

            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCnpj",
                table: "TBPESSOA",
                column: "PesCnpj",
                unique: true,
                filter: "[PesCnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA",
                column: "PesCpf",
                unique: true,
                filter: "[PesCpf] IS NOT NULL");
        }
    }
}
