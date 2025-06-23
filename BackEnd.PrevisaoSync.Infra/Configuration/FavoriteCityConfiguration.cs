using BackEnd.PrevisaoSync.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.PrevisaoSync.Infra.Configuration;
public class FavoriteCityConfiguration : IEntityTypeConfiguration<FavoriteCity>
{
    public void Configure(EntityTypeBuilder<FavoriteCity> builder)
    {
        #region table name
        builder.ToTable("FavoriteCities");
        #endregion

        #region properties
        builder.HasKey(fc => fc.Id);
        builder.Property(fc => fc.Id)
            .HasColumnType("int");
        builder.Property(fc => fc.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");
        builder.Property(fc => fc.Code)
            .HasMaxLength(20)
            .HasColumnType("nvarchar(20)");
        builder.Property(fc => fc.Lon)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        builder.Property(fc => fc.Lat)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        builder.Property(fc => fc.UserId)
            .IsRequired()
            .HasColumnType("int");
        builder.Property(fc => fc.Icon)
            .HasMaxLength(50)
            .HasColumnType("nvarchar(50)")
            .IsRequired(false);
        builder.Property(fc => fc.Temp)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        builder.Property(fc => fc.Feels_like)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        builder.Property(fc => fc.Description)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();
        builder.Property(fc => fc.Humidity)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        builder.Property(fc => fc.Speed)
            .HasColumnType("float")
            .HasDefaultValue(0.0)
            .IsRequired();
        #endregion

        #region relationships
        builder.HasOne(fc => fc.User)
            .WithMany(u => u.FavoriteCities)
            .HasForeignKey(fc => fc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}
