using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_IdUsarioPropietario",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_IdUsarioPropietario",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "IdUsarioPropietario",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioProietario",
                table: "Tareas",
                newName: "IdUsuarioPropietario");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tareas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdUsuarioPropietario",
                table: "Tareas",
                column: "IdUsuarioPropietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_IdUsuarioPropietario",
                table: "Tareas",
                column: "IdUsuarioPropietario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Usuarios_IdUsuarioPropietario",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_IdUsuarioPropietario",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioPropietario",
                table: "Tareas",
                newName: "IdUsuarioProietario");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tareas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "IdUsarioPropietario",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdUsarioPropietario",
                table: "Tareas",
                column: "IdUsarioPropietario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_IdUsarioPropietario",
                table: "Tareas",
                column: "IdUsarioPropietario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
