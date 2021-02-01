using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelContabil.Repository.Migrations
{
    public partial class balancodia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancosDias",
                columns: table => new
                {
                    DataBalanco = table.Column<DateTime>(nullable: false),
                    ValorTotalCredito = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ValorTotalDebito = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancosDias");
        }
    }
}
