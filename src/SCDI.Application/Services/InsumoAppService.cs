using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCDI.Domain.Entities;
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

        public async Task<IEnumerable<Insumo>> ListarTodosAsync()
        {
            return await _insumoRepository.GetAllAsync();
        }

        public async Task<Insumo> ObterPorIdAsync(Guid id)
        {
            return await _insumoRepository.GetByIdAsync(id);
        }

        public async Task CriarInsumoAsync(string nome, int quantidade, decimal precoUnitario, int limiteMinimoAlerta)
        {
            var novoInsumo = new Insumo(nome, quantidade, precoUnitario, limiteMinimoAlerta);
            await _insumoRepository.AddAsync(novoInsumo);
        }

        public async Task AtualizarInsumoAsync(Guid id, string nome, int quantidade, decimal precoUnitario, int limiteMinimoAlerta)
        {
            var insumoExistente = await _insumoRepository.GetByIdAsync(id);
            if (insumoExistente == null)
                throw new Exception("Insumo não encontrado.");

            insumoExistente.AtualizarDados(nome, quantidade, precoUnitario, limiteMinimoAlerta);
            _insumoRepository.Update(insumoExistente);
        }

        public async Task DeletarInsumoAsync(Guid id)
        {
            var insumo = await _insumoRepository.GetByIdAsync(id);
            if (insumo == null)
                throw new Exception("Insumo não encontrado.");

            _insumoRepository.Delete(insumo);
        }
    }
}