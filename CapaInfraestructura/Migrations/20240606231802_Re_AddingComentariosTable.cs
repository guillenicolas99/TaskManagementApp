using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Re_AddingComentariosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentarioTxt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaComentario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTarea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Tareas_IdTarea",
                        column: x => x.IdTarea,
                        principalTable: "Tareas",
                        principalColumn: "IdTarea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdTarea",
                table: "Comentarios",
                column: "IdTarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");
        }
    }
}
