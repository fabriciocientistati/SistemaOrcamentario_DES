using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    /// <inheritdoc />
    public partial class IncluindoDataNotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO");

            migrationBuilder.AlterColumn<string>(
                name: "UsuLogin",
                table: "TBUSUARIO",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrcTipoPagamento",
                table: "TBORCAMENTO",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrcTipoEntrega",
                table: "TBORCAMENTO",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrcAltEm",
                table: "TBORCAMENTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrcAltPor",
                table: "TBORCAMENTO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrcIncPor",
                table: "TBORCAMENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO",
                column: "UsuLogin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO");

            migrationBuilder.DropColumn(
                name: "OrcAltEm",
                table: "TBORCAMENTO");

            migrationBuilder.DropColumn(
                name: "OrcAltPor",
                table: "TBORCAMENTO");

            migrationBuilder.DropColumn(
                name: "OrcIncPor",
                table: "TBORCAMENTO");

            migrationBuilder.AlterColumn<string>(
                name: "UsuLogin",
                table: "TBUSUARIO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OrcTipoPagamento",
                table: "TBORCAMENTO",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.AlterColumn<string>(
                name: "OrcTipoEntrega",
                table: "TBORCAMENTO",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.CreateIndex(
                name: "IX_TBUSUARIO_UsuLogin",
                table: "TBUSUARIO",
                column: "UsuLogin",
                unique: true,
                filter: "[UsuLogin] IS NOT NULL");
        }
    }
}
