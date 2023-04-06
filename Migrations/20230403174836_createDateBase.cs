using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaOrcamentario.Migrations
{
    public partial class createDateBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cpf = table.Column<decimal>(type: "numeric(11)", nullable: false),
                    Cnpj = table.Column<decimal>(type: "numeric(14)", nullable: false),
                    NumberCellPhone = table.Column<decimal>(type: "numeric(11)", nullable: false),
                    NumberFixPhone = table.Column<decimal>(type: "numeric(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cep = table.Column<decimal>(type: "numeric(8)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<decimal>(type: "numeric(5)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(250)", nullable: true),
                    Preco = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    TipoPagamento = table.Column<string>(type: "varchar(80)", nullable: true),
                    TipoEntrega = table.Column<string>(type: "varchar(50)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_Pessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_PessoaID",
                table: "Orcamento",
                column: "PessoaID");
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
