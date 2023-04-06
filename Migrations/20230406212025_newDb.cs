using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    NumberCellPhone = table.Column<string>(type: "varchar(11)", nullable: false),
                    NumberFixPhone = table.Column<string>(type: "varchar(10)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(5)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "char(2)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(250)", nullable: true),
                    Preco = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    TipoPagamento = table.Column<string>(type: "varchar(80)", nullable: true),
                    TipoEntrega = table.Column<string>(type: "varchar(50)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PessoaModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orcamento_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Pessoa_PessoaModelID",
                        column: x => x.PessoaModelID,
                        principalTable: "Pessoa",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PessoaID",
                table: "Orcamento",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PessoaModelID",
                table: "Orcamento",
                column: "PessoaModelID");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoModel_ID",
                table: "Orcamento",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
