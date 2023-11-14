using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class OrganizacaoTabelasApp001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPESSOA",
                columns: table => new
                {
                    PesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesCpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesNumCelular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesNumTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesCep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesRua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesCidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesIncEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPESSOA", x => x.PesId);
                });

            migrationBuilder.CreateTable(
                name: "TBUSUARIO",
                columns: table => new
                {
                    UsuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuPerfil = table.Column<int>(type: "int", nullable: false),
                    UsuIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBUSUARIO", x => x.UsuId);
                });

            migrationBuilder.CreateTable(
                name: "TBORCAMENTO",
                columns: table => new
                {
                    OrcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesId = table.Column<int>(type: "int", nullable: false),
                    OrcDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrcObservacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrcPreco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrcTipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrcTipoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrcIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrcamentoPessoaPesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBORCAMENTO", x => x.OrcId);
                    table.ForeignKey(
                        name: "FK_TBORCAMENTO_TBPESSOA_OrcamentoPessoaPesId",
                        column: x => x.OrcamentoPessoaPesId,
                        principalTable: "TBPESSOA",
                        principalColumn: "PesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBORCAMENTO_OrcamentoPessoaPesId",
                table: "TBORCAMENTO",
                column: "OrcamentoPessoaPesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBORCAMENTO");

            migrationBuilder.DropTable(
                name: "TBUSUARIO");

            migrationBuilder.DropTable(
                name: "TBPESSOA");
        }
    }
}
