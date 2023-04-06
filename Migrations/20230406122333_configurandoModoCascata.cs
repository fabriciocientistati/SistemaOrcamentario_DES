using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    public partial class configurandoModoCascata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaID",
                table: "Orcamento");

            migrationBuilder.AddColumn<int>(
                name: "PessoaModelID",
                table: "Orcamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PessoaModelID",
                table: "Orcamento",
                column: "PessoaModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaID",
                table: "Orcamento",
                column: "PessoaID",
                principalTable: "Pessoa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaModelID",
                table: "Orcamento",
                column: "PessoaModelID",
                principalTable: "Pessoa",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaID",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaModelID",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_PessoaModelID",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "PessoaModelID",
                table: "Orcamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Pessoa_PessoaID",
                table: "Orcamento",
                column: "PessoaID",
                principalTable: "Pessoa",
                principalColumn: "ID");
        }
    }
}
