using Microsoft.AspNetCore.Mvc;
using SCDI.Application.DTOs;
using SCDI.Application.Services;

namespace SCDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumosController : ControllerBase
    {
        private readonly InsumoAppService _insumoAppService;

        public InsumosController(InsumoAppService insumoAppService)
        {
            _insumoAppService = insumoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarInsumoDto dto)
        {
            var resultado = await _insumoAppService.CriarInsumoAsync(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _insumoAppService.ObterTodosAsync();
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] CriarInsumoDto dto)
        {
            var sucesso = await _insumoAppService.AtualizarInsumoAsync(id, dto);
            if (!sucesso) return NotFound(new { mensagem = "Insumo não encontrado" });
            return Ok(new { mensagem = "Insumo atualizado com sucesso" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var sucesso = await _insumoAppService.DeletarInsumoAsync(id);
            if (!sucesso) return NotFound(new { mensagem = "Insumo não encontrado" });
            return Ok(new { message = "Insumo removido com sucesso" });
        }
    }
}
