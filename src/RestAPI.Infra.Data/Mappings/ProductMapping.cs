using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestAPI.Domain.Entities;

namespace RestAPI.Infra.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name);

            builder.Property(c => c.Description);

            builder.Property(c => c.Image);

            builder.Property(c => c.QuantityAvailable);

            builder.Property(c => c.IsActive);

            builder.Property(c => c.UnitOfMeasurement);

            builder.OwnsOne(c => c.Currency, cm =>
            {
                cm.Property(c => c.Value)
                    .HasColumnName("Value");

                cm.Property(c => c.CurrencyCode)
                    .HasColumnName("CurrencyCode");
            });
        }
    }
}
