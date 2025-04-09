/*-----------------------------------------------------------------------------------*
 * File Name        : EMS_DBContext.cs                                                *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : DbContext for the EMS system, managing all database entities   *
 *-----------------------------------------------------------------------------------*/

using Microsoft.EntityFrameworkCore;
using EMS.models.Equipments;
using EMS.models.Events;
using EMS.models.Persons;
using EMS.models.Vehicles;
using EMS.models;
using EMS.models.Teams;
using EMS.services;

namespace EMS.Data
{
    #region DbContext Class Definition

    /// <summary>
    /// The DbContext class for the EMS (Emergency Management System) database.
    /// It includes DbSets for all the system entities and configurations using Fluent API.
    /// </summary>
    public class EMS_DBContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EMS_DBContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public EMS_DBContext(DbContextOptions<EMS_DBContext> options) : base(options)
        {
        }

        #endregion

        #region DbSets - Entities representing tables

        // Define DbSets for all entities in the system, representing tables in the database.
        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<CatastropheEvent> Catastrophes_Event { get; set; }
        public DbSet<FireEvent> Fire_Events { get; set; }
        public DbSet<MedicalEvent> Medical_Events { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Paramedic> Paramedics { get; set; }
        public DbSet<FireFighter> FireFighters { get; set; }
        public DbSet<FireStation> Fire_Station { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Helicopter> Helicopters { get; set; }
        public DbSet<MotorBike> MotorBikes { get; set; }
        public DbSet<Team> Teams { get; set; }

        #endregion

        #region OnModelCreating - Fluent API Configurations

        /// <summary>
        /// Configures the model by overriding this method.
        /// This method is used to apply additional configurations to the model using Fluent API.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Equipment and Fire Station Configuration

            // Configure the Equipment and Fire Station entities and map them to their respective tables
            modelBuilder.Entity<Equipment>().ToTable("Equipments").HasKey(e => e.Id);
            modelBuilder.Entity<FireStation>().ToTable("Fire_Station").HasKey(e => e.Id);

            #endregion

            #region Event and Derived Types (TPT - Table-per-Type)

            // Configure the Event entity and its derived types (CatastropheEvent, FireEvent, MedicalEvent) for Table-per-Type inheritance
            modelBuilder.Entity<Event>().ToTable("Event").HasKey(e => e.Id);

            modelBuilder.Entity<CatastropheEvent>()
                .ToTable("CatastropheEvent")
                .HasBaseType<Event>()
                .Property(e => e.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<FireEvent>()
                .ToTable("FireEvent")
                .HasBaseType<Event>()
                .Property(e => e.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<MedicalEvent>()
                .ToTable("MedicalEvent")
                .HasBaseType<Event>()
                .Property(e => e.Id)
                .HasColumnName("Id");

            #endregion

            #region Event Relationships

            // Configure many-to-many relationships between Event and Team
            modelBuilder.Entity<Event>()
                .HasMany(e => e.TeamsInvolved)
                .WithMany(t => t.EventsInvolved)
                .UsingEntity<Dictionary<string, object>>(
                    "EventTeam",
                    join => join.HasOne<Team>().WithMany().HasForeignKey("TeamId").OnDelete(DeleteBehavior.Cascade),
                    join => join.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.Cascade));

            // Configure many-to-many relationships between Event and Vehicle
            modelBuilder.Entity<Event>()
                .HasMany(e => e.VehiclesInvolved)
                .WithMany(v => v.EventsInvolved)
                .UsingEntity<Dictionary<string, object>>(
                    "EventVehicle",
                    join => join.HasOne<Vehicle>().WithMany().HasForeignKey("VehicleId").OnDelete(DeleteBehavior.Cascade),
                    join => join.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.Cascade));

            #endregion

            #region Person and Derived Types

            // Configure the Person entity and its derived types (Nurse, Patient, Doctor, Paramedic, FireFighter)
            modelBuilder.Entity<Person>().ToTable("Persons").HasKey(p => p.Id);
            modelBuilder.Entity<Nurse>().ToTable("Nurses").HasBaseType<Person>();
            modelBuilder.Entity<Patient>().ToTable("Patients").HasBaseType<Person>();
            modelBuilder.Entity<Doctor>().ToTable("Doctors").HasBaseType<Person>();
            modelBuilder.Entity<Paramedic>().ToTable("Paramedics").HasBaseType<Person>();
            modelBuilder.Entity<FireFighter>().ToTable("FireFighters").HasBaseType<Person>();

            #endregion

            #region Vehicle and Derived Types

            // Configure the Vehicle entity and its derived types (Ambulance, FireTruck, Helicopter, MotorBike)
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles").HasKey(v => v.CarRegist);
            modelBuilder.Entity<Ambulance>().ToTable("Ambulances").HasBaseType<Vehicle>();
            modelBuilder.Entity<FireTruck>().ToTable("FireTrucks").HasBaseType<Vehicle>();
            modelBuilder.Entity<Helicopter>().ToTable("Helicopters").HasBaseType<Vehicle>();
            modelBuilder.Entity<MotorBike>().ToTable("MotorBikes").HasBaseType<Vehicle>();

            #endregion

            #region Teams

            // Configure the Team entity and map it to the Teams table
            modelBuilder.Entity<Team>().ToTable("Teams").HasKey(t => t.Id);

            #endregion

            #region User Configuration

            // Configure the User entity, including unique index on UserName
            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.UserId);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            #endregion
        }

        #endregion

        #region OnConfiguring - Default Connection String

        /// <summary>
        /// Configures the database connection string. If no connection string is configured, it uses the default.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Default connection string for SQL Server
                optionsBuilder.UseSqlServer("Server=LAPTOPHUGOLOPES\\SQLEXPRESS;Database=EMS;Trusted_Connection=True;Encrypt=False");
            }
        }

        #endregion
    }

    #endregion
}

