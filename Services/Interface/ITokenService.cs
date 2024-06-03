using WebApiExercisio.Models;

namespace WebApiExercisio.Services.Interface
{
    public interface ITokenService
    {
        public string GenerateToken(PessoaModel user);
    }
}
