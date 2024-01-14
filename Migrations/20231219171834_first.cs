using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CR_Proiect.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rege",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rege", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Regina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Biserica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegeID = table.Column<int>(type: "int", nullable: true),
                    ReginaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biserica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Biserica_Rege_RegeID",
                        column: x => x.RegeID,
                        principalTable: "Rege",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Biserica_Regina_ReginaID",
                        column: x => x.ReginaID,
                        principalTable: "Regina",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suprafata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capitala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegeID = table.Column<int>(type: "int", nullable: true),
                    ReginaID = table.Column<int>(type: "int", nullable: true),
                    BisericaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tara_Biserica_BisericaID",
                        column: x => x.BisericaID,
                        principalTable: "Biserica",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tara_Rege_RegeID",
                        column: x => x.RegeID,
                        principalTable: "Rege",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tara_Regina_ReginaID",
                        column: x => x.ReginaID,
                        principalTable: "Regina",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biserica_RegeID",
                table: "Biserica",
                column: "RegeID");

            migrationBuilder.CreateIndex(
                name: "IX_Biserica_ReginaID",
                table: "Biserica",
                column: "ReginaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tara_BisericaID",
                table: "Tara",
                column: "BisericaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tara_RegeID",
                table: "Tara",
                column: "RegeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tara_ReginaID",
                table: "Tara",
                column: "ReginaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropTable(
                name: "Biserica");

            migrationBuilder.DropTable(
                name: "Rege");

            migrationBuilder.DropTable(
                name: "Regina");
        }
    }
}
