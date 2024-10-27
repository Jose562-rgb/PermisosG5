using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoControlDeParqueos.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisoLaboral_Empleados_EmpleadosIdEmpleado",
                table: "PermisoLaboral");

            migrationBuilder.DropIndex(
                name: "IX_PermisoLaboral_EmpleadosIdEmpleado",
                table: "PermisoLaboral");

            migrationBuilder.DropColumn(
                name: "EmpleadosIdEmpleado",
                table: "PermisoLaboral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadosIdEmpleado",
                table: "PermisoLaboral",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermisoLaboral_EmpleadosIdEmpleado",
                table: "PermisoLaboral",
                column: "EmpleadosIdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoLaboral_Empleados_EmpleadosIdEmpleado",
                table: "PermisoLaboral",
                column: "EmpleadosIdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado");
        }
    }
}
