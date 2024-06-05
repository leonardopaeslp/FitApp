using System.ComponentModel.DataAnnotations;

namespace WebApiExercisio.ViewModels.Exercicio
{
    public class TipoExercicioViewDto
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
