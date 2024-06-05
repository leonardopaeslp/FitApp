using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExercicio.Constantes;
using WebApiExercicio.ViewModels.Exercicio;
using WebApiExercisio.Data;
using WebApiExercisio.Models;
using WebApiExercisio.ViewModels.Exercicio;

namespace WebApiExercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeExercicioController : ControllerBase
    {

        [HttpGet("v1/GetTipoExercicioPorPessoa")]
        [Authorize]
        public async Task<IActionResult> GetTipoExercicioPorPessoa([FromServices] AppDbContext context)
        {
            var pessoa = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (pessoa == null) return NotFound();  

            var tiposExercicio = await context.TiposDeExercicio
                .Where(p => p.PessoaId == pessoa.Id)
                .Select(x => new TipoExercicioViewDto { 
                Id = x.Id,
                Nome = x.Nome,  
                }).ToArrayAsync();

            return Ok(tiposExercicio);
        }

        [HttpPost("v1/CadastrarTipoExercicio")]
        [Authorize]
        public async Task<IActionResult> CadastrarTipoExercicio([FromBody] TipoExercicioViewModel model, [FromServices] AppDbContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pessoa = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (pessoa == null) return NotFound();
            try {

                var tipoExercicio = new TipoExercicioModel
                {
                    Nome = model.Nome,
                    PessoaId = pessoa.Id,
                    Pessoa = pessoa
                };

                context.TiposDeExercicio.Add(tipoExercicio);
                await context.SaveChangesAsync();

                var retorno = new TipoExercicioViewDto
                {
                    Id = tipoExercicio.Id,
                    Nome = tipoExercicio.Nome,
                };

                return Ok(retorno);
            }
            catch (DbUpdateException dbEx) {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }

            catch (Exception ex)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }
        }

        [HttpPut("v1/AtualizarTipoExercicio/{id:int}")]
        [Authorize]
        public async Task<IActionResult> AtualizarTipoExercicio([FromRoute] int id, [FromBody] TipoExercicioViewModel model, [FromServices] AppDbContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pessoa = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (pessoa == null) return NotFound();

            var tipoExercicio = await context.TiposDeExercicio.FirstOrDefaultAsync(e => e.Id == id && e.PessoaId == pessoa.Id);

            if(tipoExercicio == null) return NotFound("Tipo de exercício não encontrado");

            try
            {
                tipoExercicio.Nome = model.Nome;

                context.TiposDeExercicio.Update(tipoExercicio);
                await context.SaveChangesAsync();

                return Ok($"Tipo de exercício {tipoExercicio.Nome} atualizado com sucesso.");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }

            catch (Exception ex)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }

        }
        

        [HttpDelete("v1/DeletarTipoExercicio/{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeletarTipoExercicio([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var pessoa = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (pessoa == null) return NotFound();

            var tipoExercicio = await context.TiposDeExercicio.FirstOrDefaultAsync(e => e.Id == id && e.PessoaId == pessoa.Id);
            
            if (tipoExercicio == null) return NotFound("Tipo de exercício não encontrado.");
            
            try
            {
                context.TiposDeExercicio.Remove(tipoExercicio);
                await context.SaveChangesAsync();

                return Ok($"Tipo de exercício {tipoExercicio.Nome} deletado com sucesso.");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }

            catch (Exception ex)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }

        }
    }
}
