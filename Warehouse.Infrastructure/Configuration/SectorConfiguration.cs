using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure.Configuration;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        builder.ToTable("sectors");

        builder.HasKey(e => e.Id);


        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();


        builder.HasMany(s => s.StorageCells)
            .WithOne(sc => sc.Sector)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}
