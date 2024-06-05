using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class addingColClaseInPrioridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Clase",
                table: "Prioridades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Prioridades",
                keyColumn: "IdPrioridad",
                keyValue: 1,
                column: "Clase",
                value: "badge text-bg-danger");

            migrationBuilder.UpdateData(
                table: "Prioridades",
                keyColumn: "IdPrioridad",
                keyValue: 2,
                column: "Clase",
                value: "badge text-bg-warning");

            migrationBuilder.UpdateData(
                table: "Prioridades",
                keyColumn: "IdPrioridad",
                keyValue: 3,
                column: "Clase",
                value: "badge text-bg-success");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Prioridades");
        }
    }
}
