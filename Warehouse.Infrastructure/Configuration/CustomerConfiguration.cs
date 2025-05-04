using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id");
        builder.Property(e => e.FirstName)
            .HasColumnName("first_name")
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasColumnName("last_name")
            .IsRequired();
        builder.Property(e => e.SecondName)
            .HasColumnName("second_name");
        builder.Property(e => e.PhoneNumber)
            .HasColumnName("phone")
            .IsRequired();
        builder.Property(e => e.Email)
            .HasColumnName("email")
            .IsRequired();
        builder.Property(e => e.Address)
            .HasColumnName("address")
            .IsRequired();

        builder.HasMany(c => c.Items)
            .WithOne(i => i.Customer);
    }
}
