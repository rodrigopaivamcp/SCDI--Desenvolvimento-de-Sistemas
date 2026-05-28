using Microsoft.EntityFrameworkCore;
using SCDI.Domain;
using SCDI.Infrastructure.Data.Mappings;

namespace SCDI.Infrastructure.Data;

public class ScdiDbContext : DbContext
{
    public ScdiDbContext(DbContextOptions<ScdiDbContext> options) : base(options)
    {
    }

    public DbSet<Insumo> Insumos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InsumoConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
