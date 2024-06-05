using System.ComponentModel.DataAnnotations;
namespace WebApiExercicio.ViewModels.Exercicio
{
    public class TipoExercicioViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
    }
}
