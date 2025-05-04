using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");

        builder.HasKey(e => e.Id);

        builder.Property(i => i.Id)
            .HasColumnName("id")
            .IsRequired();
        builder.Property(i => i.Name)
            .HasColumnName("name");
        builder.Property(i => i.Height)
            .HasColumnName("height")
            .IsRequired();
        builder.Property(i => i.Width)
            .HasColumnName("width");
        builder.Property(i => i.Depth)
            .HasColumnName("depth")
            .IsRequired();
        builder.Property(i => i.InStorage)
            .HasColumnName("in_storage")
            .IsRequired();
        builder.Property(i => i.InProcessing)
            .HasColumnName("in_processing")
            .IsRequired();

        builder.HasOne(i => i.Customer)
            .WithMany(c => c.Items);

        builder.HasOne(i => i.Cell)
            .WithOne(sc => sc.StoredItem)
            .HasForeignKey<StorageCell>(sc => sc.Id);
    }
}
