namespace WebApiExercisio.ViewModels.Exercicio
{
    public class ExercicioTotalViewDto
    {
        public decimal? TotalCaloriasPerdidas { get; set; }
        public decimal? TotalKilometragem { get; set; }
        public TimeSpan TotalTempoDeDuracao { get; set; }
        public List<ExercicioPorPessoaDto> Exercicios { get; set; }
    }
}
