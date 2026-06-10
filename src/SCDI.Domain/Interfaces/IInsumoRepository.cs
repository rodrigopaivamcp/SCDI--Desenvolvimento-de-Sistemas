using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCDI.Domain.Entities; // <-- Essa linha garante que ele ache o Insumo

namespace SCDI.Domain.Interfaces
{
    public interface IInsumoRepository
    {
        Task<Insumo> GetByIdAsync(Guid id);
        Task<IEnumerable<Insumo>> GetAllAsync();
        Task AddAsync(Insumo insumo);
        void Update(Insumo insumo);
        void Delete(Insumo insumo);
    }
}