using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoPesOrc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBORCAMENTO_TBPESSOA_OrcamentoPessoaPesId",
                table: "TBORCAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_TBORCAMENTO_OrcamentoPessoaPesId",
                table: "TBORCAMENTO");

            migrationBuilder.DropColumn(
                name: "OrcamentoPessoaPesId",
                table: "TBORCAMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_TBORCAMENTO_PesId",
                table: "TBORCAMENTO",
                column: "PesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBORCAMENTO_TBPESSOA_PesId",
                table: "TBORCAMENTO",
                column: "PesId",
                principalTable: "TBPESSOA",
                principalColumn: "PesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBORCAMENTO_TBPESSOA_PesId",
                table: "TBORCAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_TBORCAMENTO_PesId",
                table: "TBORCAMENTO");

            migrationBuilder.AddColumn<int>(
                name: "OrcamentoPessoaPesId",
                table: "TBORCAMENTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBORCAMENTO_OrcamentoPessoaPesId",
                table: "TBORCAMENTO",
                column: "OrcamentoPessoaPesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBORCAMENTO_TBPESSOA_OrcamentoPessoaPesId",
                table: "TBORCAMENTO",
                column: "OrcamentoPessoaPesId",
                principalTable: "TBPESSOA",
                principalColumn: "PesId");
        }
    }
}
