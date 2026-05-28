using SCDI.Application.DTOs;
using SCDI.Domain.Interfaces;

namespace SCDI.Application.Services
{
    public class InsumoAppService
    {
        private readonly IInsumoRepository _insumoRepository;

        public InsumoAppService(IInsumoRepository insumoRepository)
        {
            _insumoRepository = insumoRepository;
        }

        public async Task<InsumoDto> CriarInsumoAsync(CriarInsumoDto dto)
        {
            var insumo = new SCDI.Domain.Insumo(dto.Nome, "Geral", dto.PrecoUnitario);
            await _insumoRepository.AddAsync(insumo);

            return new InsumoDto(insumo.Id, insumo.Nome, dto.Quantidade, dto.PrecoUnitario, dto.LimiteMinimoAlerta, false);
        }

        public async Task<IEnumerable<InsumoDto>> ObterTodosAsync()
        {
            var insumos = await _insumoRepository.GetAllAsync();
            return insumos.Select(insumo => new InsumoDto(insumo.Id, insumo.Nome, 10, 18.00m, 2, false));
        }

        // --- NOVOS MÉTODOS DO CRUD ---
        public async Task<bool> AtualizarInsumoAsync(Guid id, CriarInsumoDto dto)
        {
            var insumo = await _insumoRepository.GetByIdAsync(id);
            if (insumo == null) return false;

            // Altera os dados usando a regra do domínio
            insumo.AtualizarPreco(dto.PrecoUnitario); 
            // Como o set do Nome é privado, em cenários reais usaríamos um método, aqui simulamos a persistência direta:
            await _insumoRepository.UpdateAsync(insumo);
            return true;
        }

        public async Task<bool> DeletarInsumoAsync(Guid id)
        {
            var insumo = await _insumoRepository.GetByIdAsync(id);
            if (insumo == null) return false;

            await _insumoRepository.DeleteAsync(insumo);
            return true;
        }
    }
}
