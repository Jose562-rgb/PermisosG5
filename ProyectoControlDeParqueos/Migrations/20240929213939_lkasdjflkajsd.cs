using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoControlDeParqueos.Migrations
{
    /// <inheritdoc />
    public partial class lkasdjflkajsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    personaidPersona = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.nombre);
                    table.ForeignKey(
                        name: "FK_cargos_personas_personaidPersona",
                        column: x => x.personaidPersona,
                        principalTable: "personas",
                        principalColumn: "idPersona");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargos_personaidPersona",
                table: "cargos",
                column: "personaidPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargos");
        }
    }
}
