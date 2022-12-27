using BookingEksamenDataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingEksamenDataManager.Data;

public class DatabaseContext
    : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserInfo>? UserInfos { get; set; }
    public virtual DbSet<Artist>? Artists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasNoKey();
            entity.ToTable("UserInfo");
            entity.Property(e => e.UserId).HasColumnName("UserId");
            entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.CreatedDate).IsUnicode(false);
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");
            entity.Property(e => e.ArtistID).HasColumnName("ArtistID");
            entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            entity.Property(e => e.StartDate).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).IsUnicode(false);
        });
    }
}