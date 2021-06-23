using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.AgenziaViaggiEF.Migrations
{
    public partial class AdditionalEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Partecipante",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Partecipante");
        }
    }
}
