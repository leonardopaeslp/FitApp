using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExercicio.Constantes;
using WebApiExercisio.Data;

namespace WebApiExercisio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("v1/GetPessoa")]
        [Authorize]
        public async Task<IActionResult> GetPessoa([FromServices] AppDbContext context)
        {
            try
            {
                var pessoa = await context.Pessoas
                    .Include(p => p.Exercicios)
                    .Include(p => p.TiposDeExercicio)
                    .Include(p => p.AlteracoesDePeso)
                    .SingleOrDefaultAsync(p => p.Nome == User.Identity.Name);

                if (pessoa == null)
                {
                    return NotFound("Pessoa não encontrada.");
                }

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }
        }
    }
}
