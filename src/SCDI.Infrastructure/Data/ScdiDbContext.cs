using Microsoft.EntityFrameworkCore;
using SCDI.Domain.Entities;

namespace SCDI.Infrastructure.Data
{
    public class ScdiDbContext : DbContext
    {
        public ScdiDbContext(DbContextOptions<ScdiDbContext> options) : base(options) { }

        public DbSet<Insumo> Insumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScdiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}