using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiExercisio.Migrations
{
    /// <inheritdoc />
    public partial class AddNovasRelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlteracoesDePeso_Pessoas_PessoaId",
                table: "AlteracoesDePeso");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Pessoas_PessoaId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_TiposDeExercicio_TipoExercicioId",
                table: "Exercicios");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "TiposDeExercicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeExercicio_PessoaId",
                table: "TiposDeExercicio",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlteracoesDePeso_Pessoas_PessoaId",
                table: "AlteracoesDePeso",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Pessoas_PessoaId",
                table: "Exercicios",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_TiposDeExercicio_TipoExercicioId",
                table: "Exercicios",
                column: "TipoExercicioId",
                principalTable: "TiposDeExercicio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposDeExercicio_Pessoas_PessoaId",
                table: "TiposDeExercicio",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlteracoesDePeso_Pessoas_PessoaId",
                table: "AlteracoesDePeso");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Pessoas_PessoaId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_TiposDeExercicio_TipoExercicioId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposDeExercicio_Pessoas_PessoaId",
                table: "TiposDeExercicio");

            migrationBuilder.DropIndex(
                name: "IX_TiposDeExercicio_PessoaId",
                table: "TiposDeExercicio");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "TiposDeExercicio");

            migrationBuilder.AddForeignKey(
                name: "FK_AlteracoesDePeso_Pessoas_PessoaId",
                table: "AlteracoesDePeso",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Pessoas_PessoaId",
                table: "Exercicios",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_TiposDeExercicio_TipoExercicioId",
                table: "Exercicios",
                column: "TipoExercicioId",
                principalTable: "TiposDeExercicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
