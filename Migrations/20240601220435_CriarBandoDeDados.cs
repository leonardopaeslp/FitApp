using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiExercisio.Migrations
{
    /// <inheritdoc />
    public partial class CriarBandoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeExercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeExercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlteracoesDePeso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    PesoAntigo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PesoNovo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlteracoesDePeso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlteracoesDePeso_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempoDeDuracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    CaloriasPerdidas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Kilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoExercicioId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicios_TiposDeExercicio_TipoExercicioId",
                        column: x => x.TipoExercicioId,
                        principalTable: "TiposDeExercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlteracoesDePeso_PessoaId",
                table: "AlteracoesDePeso",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_PessoaId",
                table: "Exercicios",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TipoExercicioId",
                table: "Exercicios",
                column: "TipoExercicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlteracoesDePeso");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "TiposDeExercicio");
        }
    }
}
