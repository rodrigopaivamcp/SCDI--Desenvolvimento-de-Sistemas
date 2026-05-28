using Microsoft.EntityFrameworkCore;
using SCDI.Domain;
using SCDI.Domain.Interfaces;
using SCDI.Infrastructure.Data;

namespace SCDI.Infrastructure.Repositories
{
    public class InsumoRepository : IInsumoRepository
    {
        private readonly ScdiDbContext _context;

        public InsumoRepository(ScdiDbContext context)
        {
            _context = context;
        }

        public async Task<Insumo> GetByIdAsync(Guid id)
        {
            return await _context.Insumos.FindAsync(id);
        }

        public async Task<IEnumerable<Insumo>> GetAllAsync()
        {
            return await _context.Insumos.ToListAsync();
        }

        public async Task AddAsync(Insumo insumo)
        {
            await _context.Insumos.AddAsync(insumo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Insumo insumo)
        {
            _context.Insumos.Update(insumo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Insumo insumo)
        {
            _context.Insumos.Remove(insumo);
            await _context.SaveChangesAsync();
        }
    }
}
