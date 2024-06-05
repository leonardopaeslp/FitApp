namespace WebApiExercisio.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public decimal PesoAtual { get; set; }

        public string Senha { get; set; }

        public ICollection<AlteracaoDePesoModel> AlteracoesDePeso { get; set; }
        public ICollection<ExercicioModel> Exercicios { get; set; }
        public ICollection<TipoExercicioModel> TiposDeExercicio { get; set; }

        public PessoaModel()
        {
            AlteracoesDePeso = new List<AlteracaoDePesoModel>();
            Exercicios = new List<ExercicioModel>();
            TiposDeExercicio = new List<TipoExercicioModel>();
        }
    }
}
