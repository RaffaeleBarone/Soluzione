using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progetto1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Esame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Voto = table.Column<int>(type: "int", nullable: false),
                    IdStudente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Esame_Studente_IdStudente",
                        column: x => x.IdStudente,
                        principalTable: "Studente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Esame_IdStudente",
                table: "Esame",
                column: "IdStudente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Esame");

            migrationBuilder.DropTable(
                name: "Studente");
        }
    }
}
