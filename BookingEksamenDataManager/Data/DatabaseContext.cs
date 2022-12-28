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
    public virtual DbSet<Booker>? Bookers { get; set; }
    public virtual DbSet<Comment>? Comments { get; set; }

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

        modelBuilder.Entity<Booker>(entity =>
        {
            entity.ToTable("Booker");
            entity.Property(e => e.BookerID).HasColumnName("BookerID");
            entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            entity.Property(e => e.StartDate).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).IsUnicode(false);
        });
        
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.EmailAddress).HasMaxLength(256).IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(256).IsUnicode(false);
            entity.Property(e => e.FirstMidName).HasMaxLength(256).IsUnicode(false);
        });
    }
}