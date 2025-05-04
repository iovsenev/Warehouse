using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure.Configuration;

public class StorageCellConfiguration : IEntityTypeConfiguration<StorageCell>
{
    public void Configure(EntityTypeBuilder<StorageCell> builder)
    {
        builder.ToTable("storage_cells");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(e => e.Height)
            .HasColumnName("height")
            .IsRequired();
        builder.Property(e => e.Width)
            .HasColumnName("width")
            .IsRequired();
        builder.Property(e => e.Depth)
            .HasColumnName("depth")
            .IsRequired();
        builder.Property(e => e.IsLocked)
            .HasColumnName("isLocked")
            .HasDefaultValue(true)
            .IsRequired();


        builder.HasOne(sc => sc.Sector)
            .WithMany(s => s.StorageCells);

        builder.HasOne(sc => sc.StoredItem)
            .WithOne(i => i.Cell)
            .HasForeignKey<Item>(i => i.Id);
    }
}
