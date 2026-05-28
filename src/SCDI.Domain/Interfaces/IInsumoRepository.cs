using SCDI.Domain;

namespace SCDI.Domain.Interfaces
{
    public interface IInsumoRepository
    {
        Task<Insumo> GetByIdAsync(Guid id);
        Task<IEnumerable<Insumo>> GetAllAsync();
        Task AddAsync(Insumo insumo);
        Task UpdateAsync(Insumo insumo);
        Task DeleteAsync(Insumo insumo);
    }
}
