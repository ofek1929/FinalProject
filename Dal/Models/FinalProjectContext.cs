using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dal.Models
{
    public partial class FinalProjectContext : DbContext
    {
        public FinalProjectContext()
        {
        }

        public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Departure> Departures { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Landing> Landings { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ISABU43P\\SQLEXPRESS;Database=FinalProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Departure>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EnterTime).HasColumnType("datetime");

                entity.Property(e => e.LeavingTine).HasColumnType("datetime");

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.History)
                    .HasForeignKey<History>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Plane");

                entity.HasOne(d => d.StationNameNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.StationName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Stations");
            });

            modelBuilder.Entity<Landing>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PlaneId).HasColumnName("planeId");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.ToTable("Plane");

                entity.Property(e => e.PlaneId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.StationName);

                entity.Property(e => e.StationName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
