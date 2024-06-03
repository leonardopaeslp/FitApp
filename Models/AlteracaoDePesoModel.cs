namespace WebApiExercisio.Models
{
    public class AlteracaoDePesoModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public PessoaModel Pessoa { get; set; }
        public decimal PesoAntigo { get; set; }
        public decimal PesoNovo { get; set; }
        public DateTime DataDeAlteracao { get; set; }
    }
}
