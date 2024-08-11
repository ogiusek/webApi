using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.User.Models;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(256)")
            .IsRequired();

        builder.Property(u => u.IsEmailVerified)
            .HasColumnName("is_email_verified")
            .HasColumnType("boolean")
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnType("varchar(256)")
            .IsRequired();

        builder.Property(u => u.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(u => u.Surname)
            .HasColumnName("surname")
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}