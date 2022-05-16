using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rusada.DataContext
{
    public partial class RsadaDbContext : DbContext
    {
        public RsadaDbContext()
        {
        }

        public RsadaDbContext(DbContextOptions<RsadaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineModel> AirlineModel { get; set; } = null!;
        public virtual DbSet<Make> Make { get; set; } = null!;
        public virtual DbSet<Spotter> Spotter { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineModel>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Spotter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('True')");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Registration).HasMaxLength(7);

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Spotter)
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK_MakeId");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Spotter)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_AirlineModelId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
