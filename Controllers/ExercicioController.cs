using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExercicio.Constantes;
using WebApiExercisio.Data;
using WebApiExercisio.ViewModels.Exercicio;

namespace WebApiExercisio.Controllers
{
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        
        [HttpGet("v1/GetExercicios")]
        [Authorize]
        public async Task<IActionResult> GetExercicios([FromServices] AppDbContext context) {

            var userName = User.Identity.Name;

            var user = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == userName);

            if (user == null) return Unauthorized();

            try
            {

            var exercicios = await context.Exercicios.Where(e => e.PessoaId == user.Id)
                .Select(x => new ExercicioPorPessoaDto {
                Id = x.Id,
                TipoExercicioNome = x.TipoExercicio.Nome,
                CaloriasPerdidas = x.CaloriasPerdidas,
                Kilometragem = x.Kilometragem,
                TempoDeDuracao = x.TempoDeDuracao,
                DataDeCadastro = x.DataDeCadastro,
                })
                .ToListAsync(); 

            var totalCalorias = exercicios.Sum(e => e.CaloriasPerdidas);
            var totalKilometragem = exercicios.Sum(e => e.Kilometragem);
            var totalTempo = new TimeSpan(exercicios.Sum(e => e.TempoDeDuracao.Ticks));

            var resultado = new ExercicioTotalViewDto
            {
                TotalCaloriasPerdidas = totalCalorias,
                TotalKilometragem = totalKilometragem,
                TotalTempoDeDuracao = totalTempo,
                Exercicios = exercicios
            };

            return Ok(resultado);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }

        }

        [HttpGet("v1/GetExerciciosDoMesAtual")]
        [Authorize]
        public async Task<IActionResult> GetExerciciosDoMesAtual([FromServices] AppDbContext context)
        {

            var userName = User.Identity.Name;

            var user = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == userName);

            if (user == null) return Unauthorized();

            try
            {
                var exercicios = await context.Exercicios
                    .Where(e => e.PessoaId == user.Id &&
                    e.DataDeCadastro.Month == DateTime.Now.Month &&
                    e.DataDeCadastro.Year == DateTime.Now.Year
                    )
                    .OrderByDescending(e => e.DataDeCadastro)
                    .Select(x => new ExercicioPorPessoaDto
                    {
                        Id = x.Id,
                        TipoExercicioNome = x.TipoExercicio.Nome,
                        CaloriasPerdidas = x.CaloriasPerdidas,
                        Kilometragem = x.Kilometragem,
                        TempoDeDuracao = x.TempoDeDuracao,
                        DataDeCadastro = x.DataDeCadastro,
                    })
                    .ToListAsync();

                return Ok(exercicios);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }

        }

        [HttpGet("v1/GetExerciciosDosUltimos3Meses")]
        public async Task<IActionResult> GetExerciciosDosUltimos3Meses([FromServices] AppDbContext context)
        {
            var userName = User.Identity.Name;

            var user = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == userName);

            if (user == null) return Unauthorized();

            try
            {
                var ultimos3meses = DateTime.Now.AddMonths(-3);

                var exercicios = await context.Exercicios
                    .Where(e => e.PessoaId == user.Id && e.DataDeCadastro >= ultimos3meses)
                    .OrderByDescending(e => e.DataDeCadastro)
                    .Select(x => new ExercicioPorPessoaDto
                    {
                        Id = x.Id,
                        TipoExercicioNome = x.TipoExercicio.Nome,
                        CaloriasPerdidas = x.CaloriasPerdidas,
                        Kilometragem = x.Kilometragem,
                        TempoDeDuracao = x.TempoDeDuracao,
                        DataDeCadastro = x.DataDeCadastro,
                    })
                    .ToListAsync();

                return Ok(exercicios);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }
        }

        [HttpGet("v1/GetExerciciosDosUltimos6Meses")]
        public async Task<IActionResult> GetExerciciosDosUltimos6Meses([FromServices] AppDbContext context)
        {
            var userName = User.Identity.Name;

            var user = await context.Pessoas.SingleOrDefaultAsync(p => p.Nome == userName);

            if (user == null) return Unauthorized();

            try
            {
                var ultimos3meses = DateTime.Now.AddMonths(-6);

                var exercicios = await context.Exercicios
                    .Where(e => e.PessoaId == user.Id && e.DataDeCadastro >= ultimos3meses)
                    .OrderByDescending(e => e.DataDeCadastro)
                    .Select(x => new ExercicioPorPessoaDto
                    {
                        Id = x.Id,
                        TipoExercicioNome = x.TipoExercicio.Nome,
                        CaloriasPerdidas = x.CaloriasPerdidas,
                        Kilometragem = x.Kilometragem,
                        TempoDeDuracao = x.TempoDeDuracao,
                        DataDeCadastro = x.DataDeCadastro,
                    })
                    .ToListAsync();

                return Ok(exercicios);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }
        }

        [HttpGet("v1/GetTipoExercicioExercicios")]
        [Authorize]
        public async Task<IActionResult> GetTipoExercicio([FromServices] AppDbContext context)
        {

            var userName = User.Identity.Name;

            try
            {
                var pessoa = await context.Pessoas
            .Include(p => p.Exercicios)
            .ThenInclude(e => e.TipoExercicio)
            .SingleOrDefaultAsync(p => p.Nome == userName);

                if (pessoa == null)
                {
                    return NotFound("Pessoa não encontrada.");
                }

                var tipoExercicioPessoa = pessoa.Exercicios.Select(e => new TipoExercicioViewDto
                {
                    Id = e.TipoExercicioId,
                    Nome = e.TipoExercicio.Nome
                }).Distinct().ToList();

                return Ok(tipoExercicioPessoa);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, MensagensDeErro.ErroAtualizarBanco);
            }
            catch (Exception)
            {
                return StatusCode(500, MensagensDeErro.ErroInesperado);
            }
        }
    }
}
