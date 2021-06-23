using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.AgenziaViaggiEF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itinerario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partecipante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partecipante", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Responsabile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsabile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPartenza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsabileID = table.Column<int>(type: "int", nullable: false),
                    ItinerarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gita_Itinerario_ItinerarioID",
                        column: x => x.ItinerarioID,
                        principalTable: "Itinerario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gita_Responsabile_ResponsabileID",
                        column: x => x.ResponsabileID,
                        principalTable: "Responsabile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GitaPartecipante",
                columns: table => new
                {
                    GiteID = table.Column<int>(type: "int", nullable: false),
                    PartecipantiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitaPartecipante", x => new { x.GiteID, x.PartecipantiID });
                    table.ForeignKey(
                        name: "FK_GitaPartecipante_Gita_GiteID",
                        column: x => x.GiteID,
                        principalTable: "Gita",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GitaPartecipante_Partecipante_PartecipantiID",
                        column: x => x.PartecipantiID,
                        principalTable: "Partecipante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Itinerario",
                columns: new[] { "ID", "Descrizione", "Durata", "Prezzo" },
                values: new object[] { 1, "Viaggio a Londra", 15, 500.79998779296875 });

            migrationBuilder.InsertData(
                table: "Partecipante",
                columns: new[] { "ID", "Citta", "Cognome", "DataNascita", "Indirizzo", "Nome" },
                values: new object[,]
                {
                    { 1, "Milano", "Rossi", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Via dei faggi, 78", "Mario" },
                    { 2, "Bologna", "Verdi", new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Via dei ciliegi, 50", "Luca" }
                });

            migrationBuilder.InsertData(
                table: "Responsabile",
                columns: new[] { "ID", "Cognome", "Nome", "Telefono" },
                values: new object[] { 1, "Bianchi", "Roberta", "3334445556" });

            migrationBuilder.InsertData(
                table: "Gita",
                columns: new[] { "ID", "DataPartenza", "ItinerarioID", "ResponsabileID" },
                values: new object[] { 1, new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Gita_ItinerarioID",
                table: "Gita",
                column: "ItinerarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Gita_ResponsabileID",
                table: "Gita",
                column: "ResponsabileID");

            migrationBuilder.CreateIndex(
                name: "IX_GitaPartecipante_PartecipantiID",
                table: "GitaPartecipante",
                column: "PartecipantiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitaPartecipante");

            migrationBuilder.DropTable(
                name: "Gita");

            migrationBuilder.DropTable(
                name: "Partecipante");

            migrationBuilder.DropTable(
                name: "Itinerario");

            migrationBuilder.DropTable(
                name: "Responsabile");
        }
    }
}
