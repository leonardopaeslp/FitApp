using WebApiExercisio.Models;

namespace WebApiExercisio.ViewModels.Exercicio
{
    public class ExercicioPorPessoaViewModel
    {
        public int Id { get; set; }
        public TimeSpan TempoDeDuracao { get; set; }
        public decimal? CaloriasPerdidas { get; set; }
        public decimal? Kilometragem { get; set; }
        public string TipoExercicioNome { get; set; }

        public DateTime DataDeCadastro { get; set; }

    }
}
