using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCDI.Domain.Entities;
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

        public void Update(Insumo insumo)
        {
            _context.Insumos.Update(insumo);
            _context.SaveChanges();
        }

        public void Delete(Insumo insumo)
        {
            _context.Insumos.Remove(insumo);
            _context.SaveChanges();
        }
    }
}