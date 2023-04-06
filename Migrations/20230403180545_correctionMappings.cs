using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaOrcamentario.Migrations
{
    public partial class correctionMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoa",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orcamento",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pessoa",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5)");

            migrationBuilder.AlterColumn<string>(
                name: "NumberFixPhone",
                table: "Pessoa",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(10)");

            migrationBuilder.AlterColumn<string>(
                name: "NumberCellPhone",
                table: "Pessoa",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pessoa",
                type: "char(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pessoa",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Pessoa",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(14)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Pessoa",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Pessoa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orcamento",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Numero",
                table: "Pessoa",
                type: "numeric(5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NumberFixPhone",
                table: "Pessoa",
                type: "numeric(10)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NumberCellPhone",
                table: "Pessoa",
                type: "numeric(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pessoa",
                type: "varchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cpf",
                table: "Pessoa",
                type: "numeric(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cnpj",
                table: "Pessoa",
                type: "numeric(14)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cep",
                table: "Pessoa",
                type: "numeric(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)");
        }
    }
}
