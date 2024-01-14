using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CR_Proiect.Migrations
{
    public partial class remodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tara_Rege_RegeID",
                table: "Tara");

            migrationBuilder.DropForeignKey(
                name: "FK_Tara_Regina_ReginaID",
                table: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Tara_RegeID",
                table: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Tara_ReginaID",
                table: "Tara");

            migrationBuilder.DropColumn(
                name: "RegeID",
                table: "Tara");

            migrationBuilder.DropColumn(
                name: "ReginaID",
                table: "Tara");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegeID",
                table: "Tara",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReginaID",
                table: "Tara",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tara_RegeID",
                table: "Tara",
                column: "RegeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tara_ReginaID",
                table: "Tara",
                column: "ReginaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tara_Rege_RegeID",
                table: "Tara",
                column: "RegeID",
                principalTable: "Rege",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tara_Regina_ReginaID",
                table: "Tara",
                column: "ReginaID",
                principalTable: "Regina",
                principalColumn: "ID");
        }
    }
}
