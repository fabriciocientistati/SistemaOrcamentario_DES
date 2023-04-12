using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    public partial class createTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Login = table.Column<string>(type: "varchar(80)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(40)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
