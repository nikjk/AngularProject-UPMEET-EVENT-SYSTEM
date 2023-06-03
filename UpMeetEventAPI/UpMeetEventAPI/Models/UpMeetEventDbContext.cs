using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UpMeetEventAPI.Models;

public partial class UpMeetEventDbContext : DbContext
{
    public UpMeetEventDbContext()
    {
    }

    public UpMeetEventDbContext(DbContextOptions<UpMeetEventDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Favorites> Favorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=UpMeetEventDB; Integrated Security=true; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C8104CE6D0D6");

            entity.Property(e => e.CreatedBy).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EventEndDate).HasColumnType("datetime");
            entity.Property(e => e.EventLocation).HasMaxLength(50);
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.EventStartDate).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Favorites>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__Favorite__1797D0240018425D");

            entity.Property(e => e.Username).HasMaxLength(30);

            entity.HasOne(d => d.Event).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("FK__Favorites__Event__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
