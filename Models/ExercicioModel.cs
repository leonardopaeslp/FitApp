namespace WebApiExercisio.Models
{
    public class ExercicioModel
    {
        public int Id { get; set; }
        
        public TimeSpan TempoDeDuracao { get; set; }
        public decimal? CaloriasPerdidas { get; set; }
        public decimal? Kilometragem { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public int TipoExercicioId { get; set; }
        public TipoExercicioModel TipoExercicio { get; set; }

        public int PessoaId { get; set; }
        public PessoaModel Pessoa { get; set; }

    }
}
