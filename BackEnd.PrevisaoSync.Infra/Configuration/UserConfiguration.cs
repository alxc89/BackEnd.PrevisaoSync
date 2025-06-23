using BackEnd.PrevisaoSync.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.PrevisaoSync.Infra.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region table name
        builder.ToTable("Users");
        #endregion

        #region properties
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("int");
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("nvarchar(50)");
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .HasConversion<string>()
            .IsUnicode(false);
        builder.Property(u => u.PasswordHash)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("nvarchar(255)");
        #endregion

        #region relationships
        #endregion
    }
}