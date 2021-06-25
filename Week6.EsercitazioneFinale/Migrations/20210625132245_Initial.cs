using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.EsercitazioneFinale.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    TaxCode = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.TaxCode);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredAmount = table.Column<float>(type: "real", nullable: false),
                    MonthlyRate = table.Column<float>(type: "real", nullable: false),
                    CustomerCode = table.Column<string>(type: "nchar(16)", nullable: true),
                    PolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    InsuredAge = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Policy_Customer_CustomerCode",
                        column: x => x.CustomerCode,
                        principalTable: "Customer",
                        principalColumn: "TaxCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "TaxCode", "Address", "FirstName", "LastName" },
                values: new object[] { "RSSMRA80D23T123P", "Via della vittoria, 67 Milano (MI)", "Maria", "Rossi" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "TaxCode", "Address", "FirstName", "LastName" },
                values: new object[] { "SCCNTN93C56T345W", "Via D'annunzio 7", "Antonia", "Sacchitella" });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Number", "CustomerCode", "Displacement", "InsuredAmount", "MonthlyRate", "Plate", "PolicyType", "Date" },
                values: new object[] { 1, "RSSMRA80D23T123P", 2500, 2000f, 50f, "PP123", "CarInsurance", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_CustomerCode",
                table: "Policy",
                column: "CustomerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
