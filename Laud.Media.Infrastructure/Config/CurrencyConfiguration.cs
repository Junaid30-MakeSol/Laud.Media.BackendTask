using Laud.Media.Domain.Entities.Currency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laud.Media.Infrastructure.Config
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<CurrencyEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
        {
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
