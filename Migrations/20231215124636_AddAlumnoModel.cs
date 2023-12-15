using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instituto1.Migrations
{
    /// <inheritdoc />
    public partial class AddAlumnoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.CreateTable(
                name: "CursoAlumno",
                columns: table => new
                {
                    AlumnosId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoAlumno", x => new { x.AlumnosId, x.CursosId });
                    table.ForeignKey(
                        name: "FK_CursoAlumno_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoAlumno_Curso_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoAlumno_CursosId",
                table: "CursoAlumno",
                column: "CursosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoAlumno");

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    AlumnosId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => new { x.AlumnosId, x.CursosId });
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Curso_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_CursosId",
                table: "AlumnoCurso",
                column: "CursosId");
        }
    }
}
