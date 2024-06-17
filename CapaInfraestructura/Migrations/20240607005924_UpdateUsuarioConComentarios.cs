using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuarioConComentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Comentarios");
        }
    }
}
