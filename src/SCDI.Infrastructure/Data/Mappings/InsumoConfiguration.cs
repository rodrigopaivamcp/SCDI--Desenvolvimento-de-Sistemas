using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCDI.Domain;

namespace SCDI.Infrastructure.Data.Mappings
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumos");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Categoria)
                .HasMaxLength(100);

            builder.Property(i => i.PrecoUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
