namespace WebApiExercisio.Models
{
    public class TipoExercicioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaId { get; set; }
        public PessoaModel Pessoa { get; set; }
        public ICollection<ExercicioModel> Exercicios { get; set; }

        public TipoExercicioModel()
        {
            Exercicios = new List<ExercicioModel>();
        }

    }
}
