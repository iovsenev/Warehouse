using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities.Authorization;

namespace Warehouse.Infrastructure.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.Property(f => f.Id)
            .HasColumnName("id");
        builder.Property(f => f.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");
        builder.Property(f => f.LockoutEnabled)
            .HasColumnName("lockout_enabled");
        builder.Property(e => e.LockoutEnd)
            .HasColumnName("lockout_end");
        builder.Property(f => f.NormalizedEmail)
            .HasColumnName("normalized_email");
        builder.Property(f => f.PasswordHash)
            .HasColumnName("password_hash");
        builder.Property(f => f.NormalizedUserName)
            .HasColumnName("normalized_user_name");
        builder.Property(f => f.PhoneNumber)
            .HasColumnName("phone_number");
        builder.Property(f => f.PhoneNumberConfirmed)
            .HasColumnName("phone_number_confirmed");
        builder.Property(f => f.SecondName)
            .HasColumnName("second_name");
        builder.Property(f => f.FirstName)
            .HasColumnName("first_name");
        builder.Property(f => f.LastName)
            .HasColumnName("last_name");
    }
}
