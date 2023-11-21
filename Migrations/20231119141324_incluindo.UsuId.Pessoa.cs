using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class incluindoUsuIdPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PesAltEm",
                table: "TBPESSOA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PesAltPor",
                table: "TBPESSOA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PesIncPor",
                table: "TBPESSOA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA",
                column: "PesCpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBPESSOA_PesCpf",
                table: "TBPESSOA");

            migrationBuilder.DropColumn(
                name: "PesAltEm",
                table: "TBPESSOA");

            migrationBuilder.DropColumn(
                name: "PesAltPor",
                table: "TBPESSOA");

            migrationBuilder.DropColumn(
                name: "PesIncPor",
                table: "TBPESSOA");
        }
    }
}
