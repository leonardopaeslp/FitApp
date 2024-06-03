namespace WebApiExercisio.ViewModels.Exercicio
{
    public class ExercicioTotalViewModel
    {
        public decimal? TotalCaloriasPerdidas { get; set; }
        public decimal? TotalKilometragem { get; set; }
        public TimeSpan TotalTempoDeDuracao { get; set; }
        public List<ExercicioPorPessoaViewModel> Exercicios { get; set; }
    }
}
