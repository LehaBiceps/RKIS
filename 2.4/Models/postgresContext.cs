using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _2._4.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Itinerary> Itineraries { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Persontask> Persontasks { get; set; } = null!;
        public virtual DbSet<RightsCategory> RightsCategories { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TypeCar> TypeCars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.StateNumber, "car_state_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTypeCar).HasColumnName("id_type_car");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.NumberPassengers).HasColumnName("number_passengers");

                entity.Property(e => e.StateNumber)
                    .HasMaxLength(10)
                    .HasColumnName("state_number");

                entity.HasOne(d => d.IdTypeCarNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdTypeCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("car_id_type_car_fkey");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.HasMany(d => d.IdRightsCategories)
                    .WithMany(p => p.IdDrivers)
                    .UsingEntity<Dictionary<string, object>>(
                        "DriverRightsCategory",
                        l => l.HasOne<RightsCategory>().WithMany().HasForeignKey("IdRightsCategory").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("driver_rights_category_id_rights_category_fkey"),
                        r => r.HasOne<Driver>().WithMany().HasForeignKey("IdDriver").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("driver_rights_category_id_driver_fkey"),
                        j =>
                        {
                            j.HasKey("IdDriver", "IdRightsCategory").HasName("driver_rights_category_pkey");

                            j.ToTable("driver_rights_category");

                            j.IndexerProperty<int>("IdDriver").HasColumnName("id_driver");

                            j.IndexerProperty<int>("IdRightsCategory").HasColumnName("id_rights_category");
                        });
            });

            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.ToTable("itinerary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(30)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Persontask>(entity =>
            {
                entity.ToTable("persontask");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPerson).HasColumnName("id_person");

                entity.Property(e => e.IdTask).HasColumnName("id_task");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Persontasks)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("persontask_id_person_fkey");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Persontasks)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("persontask_id_task_fkey");
            });

            modelBuilder.Entity<RightsCategory>(entity =>
            {
                entity.ToTable("rights_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(5)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("route");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCar).HasColumnName("id_car");

                entity.Property(e => e.IdDriver).HasColumnName("id_driver");

                entity.Property(e => e.IdItinerary).HasColumnName("id_itinerary");

                entity.Property(e => e.NumberPassengers).HasColumnName("number_passengers");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_car_fkey");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.IdDriver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_driver_fkey");

                entity.HasOne(d => d.IdItineraryNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.IdItinerary)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_itinerary_fkey");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TypeCar>(entity =>
            {
                entity.ToTable("type_car");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
