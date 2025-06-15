using BackEnd.PrevisaoSync.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.PrevisaoSync.Infra.Configuration;
public class FavoriteCityConfiguration : IEntityTypeConfiguration<FavoriteCity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Core.Entities.FavoriteCity> builder)
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
        builder.Property(fc => fc.Long)
            .HasColumnType("int")
            .HasDefaultValue(0);
        builder.Property(fc => fc.Lat)
            .HasColumnType("int")
            .HasDefaultValue(0);
        builder.Property(fc => fc.UserId)
            .IsRequired()
            .HasColumnType("int");
        #endregion

        #region relationships
        builder.HasOne(fc => fc.User)
            .WithMany(u => u.FavoriteCities)
            .HasForeignKey(fc => fc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}
