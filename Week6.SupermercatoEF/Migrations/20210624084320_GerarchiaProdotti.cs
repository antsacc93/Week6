using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.SupermercatoEF.Migrations
{
    public partial class GerarchiaProdotti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataScadenza",
                table: "Prodotto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marchio",
                table: "Prodotto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prodotto_type",
                table: "Prodotto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataScadenza",
                table: "Prodotto");

            migrationBuilder.DropColumn(
                name: "Marchio",
                table: "Prodotto");

            migrationBuilder.DropColumn(
                name: "prodotto_type",
                table: "Prodotto");
        }
    }
}
