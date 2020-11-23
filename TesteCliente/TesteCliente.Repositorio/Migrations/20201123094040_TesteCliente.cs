using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCliente.Repositorio.Migrations
{
    public partial class TesteCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TesteCliente");

            migrationBuilder.CreateTable(
                name: "tbCliente",
                schema: "TesteCliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCliente",
                schema: "TesteCliente");
        }
    }
}
