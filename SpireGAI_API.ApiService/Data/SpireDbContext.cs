using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpireGAI_API.ApiService.Models;

namespace SpireGAI_API.ApiService.Data;

public partial class SpireDbContext : DbContext
{
    public SpireDbContext()
    {
    }

    public SpireDbContext(DbContextOptions<SpireDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<district> districts { get; set; }

    public virtual DbSet<incident> incidents { get; set; }

    public virtual DbSet<incident_classification> incident_classifications { get; set; }

    public virtual DbSet<incident_officer> incident_officers { get; set; }

    public virtual DbSet<incident_vehicle> incident_vehicles { get; set; }

    public virtual DbSet<officer> officers { get; set; }

    public virtual DbSet<person> people { get; set; }

    public virtual DbSet<police_department> police_departments { get; set; }

    public virtual DbSet<police_station> police_stations { get; set; }

    public virtual DbSet<rank> ranks { get; set; }

    public virtual DbSet<social_status> social_statuses { get; set; }

    public virtual DbSet<user_district_map> user_district_maps { get; set; }

    public virtual DbSet<vehicle> vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=1243");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<district>(entity =>
        {
            entity.HasKey(e => e.id).HasName("District_pkey");

            entity.ToTable("district", "gai");
        });

        modelBuilder.Entity<incident>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incidents_pkey");

            entity.ToTable("incidents", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.timestamp).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.incident_class).WithMany(p => p.incidents)
                .HasForeignKey(d => d.incident_class_id)
                .HasConstraintName("Incidents_incident_class_id_fkey");

            entity.HasOne(d => d.police_station).WithMany(p => p.incidents)
                .HasForeignKey(d => d.police_station_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Incidents_police_station_id_fkey");
        });

        modelBuilder.Entity<incident_classification>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Incident_Classification_pkey");

            entity.ToTable("incident_classification", "gai");

            entity.Property(e => e.classification_name).HasMaxLength(200);
        });

        modelBuilder.Entity<incident_officer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Incident_Officers_pkey");

            entity.ToTable("incident_officers", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.officer).WithMany(p => p.incident_officers)
                .HasForeignKey(d => d.officer_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("incident_officers_officers_fk");
        });

        modelBuilder.Entity<incident_vehicle>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Incident_Vehicles_pkey");

            entity.ToTable("incident_vehicles", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.incident).WithMany(p => p.incident_vehicles)
                .HasForeignKey(d => d.incident_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Incident_Vehicles_incident_id_fkey");

            entity.HasOne(d => d.vehicle).WithMany(p => p.incident_vehicles)
                .HasForeignKey(d => d.vehicle_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Incident_Vehicles_vehicle_id_fkey");
        });

        modelBuilder.Entity<officer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Officers_pkey");

            entity.ToTable("officers", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.first_name).HasMaxLength(20);
            entity.Property(e => e.last_name).HasMaxLength(20);
            entity.Property(e => e.middle_name).HasMaxLength(20);

            entity.HasOne(d => d.rank).WithMany(p => p.officers)
                .HasForeignKey(d => d.rank_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Officers_rank_id_fkey");
        });

        modelBuilder.Entity<person>(entity =>
        {
            entity.HasKey(e => e.id).HasName("People_pkey");

            entity.ToTable("people", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.car_brand).HasMaxLength(255);
            entity.Property(e => e.first_name).HasMaxLength(50);
            entity.Property(e => e.last_name).HasMaxLength(50);
            entity.Property(e => e.middle_name).HasMaxLength(50);

            entity.HasOne(d => d.social_status).WithMany(p => p.people)
                .HasForeignKey(d => d.social_status_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("People_social_status_id_fkey");
        });

        modelBuilder.Entity<police_department>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Police_Department_pkey");

            entity.ToTable("police_department", "gai");

            entity.Property(e => e.chief_first_name).HasMaxLength(25);
            entity.Property(e => e.chief_last_name).HasMaxLength(25);
            entity.Property(e => e.chief_middle_name).HasMaxLength(25);

            entity.HasOne(d => d.district).WithMany(p => p.police_departments)
                .HasForeignKey(d => d.district_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Police_Department_district_id_fkey");
        });

        modelBuilder.Entity<police_station>(entity =>
        {
            entity.HasKey(e => e.id).HasName("police_station_pkey");

            entity.ToTable("police_station", "gai");

            entity.Property(e => e.phone).HasMaxLength(20);

            entity.HasOne(d => d.district).WithMany(p => p.police_stations)
                .HasForeignKey(d => d.district_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Police_Station_district_id_fkey");
        });

        modelBuilder.Entity<rank>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Ranks_pkey");

            entity.ToTable("ranks", "gai");

            entity.Property(e => e.rank_name).HasMaxLength(35);
        });

        modelBuilder.Entity<social_status>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Social_Statuses_pkey");

            entity.ToTable("social_statuses", "gai");

            entity.Property(e => e.status_name).HasMaxLength(255);
        });

        modelBuilder.Entity<user_district_map>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_district_map", "gai");
        });

        modelBuilder.Entity<vehicle>(entity =>
        {
            entity.HasKey(e => e.id).HasName("Vehicles_pkey");

            entity.ToTable("vehicles", "gai");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.color).HasMaxLength(255);

            entity.HasOne(d => d.owner).WithMany(p => p.vehicles)
                .HasForeignKey(d => d.owner_id)
                .HasConstraintName("Vehicles_owner_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
