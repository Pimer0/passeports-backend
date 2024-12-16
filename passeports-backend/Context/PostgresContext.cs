using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using passeports_backend.entities;

namespace passeports_backend.Context;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avantage> Avantages { get; set; }

    public virtual DbSet<Passeport> Passeports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5435;Username=postgres;Password=passaporte;Database=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avantage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("avantages_pkey");

            entity.ToTable("avantages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenu)
                .HasMaxLength(255)
                .HasColumnName("contenu");
            entity.Property(e => e.PaysVisitables).HasColumnName("pays_visitables");
        });

        modelBuilder.Entity<Passeport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passeport_pkey");

            entity.ToTable("passeport");

            entity.HasIndex(e => e.Pays, "passeport_pays_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Pays)
                .HasMaxLength(50)
                .HasColumnName("pays");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");

            entity.HasMany(d => d.Avantages).WithMany(p => p.Passeports)
                .UsingEntity<Dictionary<string, object>>(
                    "PasseportAvantage",
                    r => r.HasOne<Avantage>().WithMany()
                        .HasForeignKey("AvantageId")
                        .HasConstraintName("passeport_avantages_avantage_id_fkey"),
                    l => l.HasOne<Passeport>().WithMany()
                        .HasForeignKey("PasseportId")
                        .HasConstraintName("passeport_avantages_passeport_id_fkey"),
                    j =>
                    {
                        j.HasKey("PasseportId", "AvantageId").HasName("passeport_avantages_pkey");
                        j.ToTable("passeport_avantages");
                        j.IndexerProperty<int>("PasseportId").HasColumnName("passeport_id");
                        j.IndexerProperty<int>("AvantageId").HasColumnName("avantage_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
