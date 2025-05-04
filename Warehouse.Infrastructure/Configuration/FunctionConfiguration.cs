using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities.Authorization;

namespace Warehouse.Infrastructure.Configuration;

public class FunctionConfiguration : IEntityTypeConfiguration<Function>
{
    public void Configure(EntityTypeBuilder<Function> builder)
    {
        builder.ToTable("functions");

        builder.Property(f => f.Id)
            .HasColumnName("id");
        builder.Property(f => f.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");
        builder.Property(f => f.NormalizedName)
            .HasColumnName("normalized_name");
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(f => f.Permisions)
            .HasColumnName("permissions");
    }
}
