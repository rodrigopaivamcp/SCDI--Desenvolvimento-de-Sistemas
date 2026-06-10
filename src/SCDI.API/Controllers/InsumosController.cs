using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCDI.Domain.Entities;
using SCDI.Infrastructure.Data; // <-- Ajustado para apontar para o lugar certo
using System;
using System.Threading.Tasks;

namespace SCDI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumosController : ControllerBase
    {
        private readonly ScdiDbContext _context;

        public InsumosController(ScdiDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> CriarInsumo([FromBody] InsumoInputModel input)
        {
            try
            {
                var novoInsumo = new Insumo(input.Nome, input.Quantidade, input.PrecoUnitario, input.LimiteMinimoAlerta);
                _context.Insumos.Add(novoInsumo);
                await _context.SaveChangesAsync();
                return Ok(novoInsumo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos() => Ok(await _context.Insumos.ToListAsync());

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarInsumo(Guid id, [FromBody] InsumoInputModel input)
        {
            var insumoExistente = await _context.Insumos.FindAsync(id);
            if (insumoExistente == null) return NotFound(new { mensagem = "Insumo não encontrado." });

            try
            {
                insumoExistente.AtualizarDados(input.Nome, input.Quantidade, input.PrecoUnitario, input.LimiteMinimoAlerta);
                await _context.SaveChangesAsync();
                return Ok(insumoExistente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarInsumo(Guid id)
        {
            var insumo = await _context.Insumos.FindAsync(id);
            if (insumo == null) return NotFound(new { mensagem = "Insumo não encontrado." });

            _context.Insumos.Remove(insumo);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Insumo excluído com sucesso!" });
        }
    }

    public class InsumoInputModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int LimiteMinimoAlerta { get; set; }
    }
}