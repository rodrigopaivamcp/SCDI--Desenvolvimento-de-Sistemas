using Microsoft.AspNetCore.Mvc;

namespace SCDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validação simples simulando uma regra de login profissional
            if (request.Usuario == "admin" && request.Senha == "admin123")
            {
                return Ok(new { 
                    mensagem = "Login efetuado com sucesso!", 
                    token = "SimulacaoTokenJWT_SCDI_2026",
                    usuario = request.Usuario 
                });
            }

            return BadRequest(new { mensagem = "Usuário ou senha inválidos!" });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
