using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExercisio.Data;
using WebApiExercisio.Models;
using WebApiExercisio.Services;
using WebApiExercisio.Services.Interface;

namespace WebApiExercisio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(
            [FromBody] LoginModel request,
            [FromServices] AppDbContext context,
            [FromServices] TokenService tokenService)
        {
            if (request == null || string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest("Nome e senha são obrigatórios.");
            }
            var pessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.Nome == request.Nome && p.Senha == request.Senha);

            
            if (pessoa == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }
            try
            {
                var token = tokenService.GenerateToken(pessoa);
                return Ok(token);
            }
            catch (Exception ex) {
                return StatusCode(500);
            }
        }

    }
}
