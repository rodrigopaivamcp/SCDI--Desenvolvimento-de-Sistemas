using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCDI.Domain.Entities;

namespace SCDI.Infrastructure.Configurations
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.Quantidade)
                   .IsRequired();

            builder.Property(i => i.PrecoUnitario)
                   .HasPrecision(18, 2);

            builder.Property(i => i.LimiteMinimoAlerta)
                   .IsRequired();
        }
    }
}