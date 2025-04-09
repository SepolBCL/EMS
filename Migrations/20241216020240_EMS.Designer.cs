﻿// <auto-generated />
using System;
using EMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMS.Migrations
{
    [DbContext(typeof(EMS_DBContext))]
    [Migration("20241216020240_EMS")]
    partial class EMS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EMS.models.Equipments.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("MaintenanceDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FireStationId");

                    b.ToTable("Equipments", (string)null);
                });

            modelBuilder.Entity("EMS.models.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndEventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeverityLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartEventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Event", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EMS.models.FireStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fire_Station", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("CitCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Profession")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Persons", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EMS.models.Teams.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("EMS.models.Vehicles.Vehicle", b =>
                {
                    b.Property<string>("CarRegist")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<int?>("FireStationId1")
                        .HasColumnType("int");

                    b.Property<int?>("FireStationId2")
                        .HasColumnType("int");

                    b.Property<int?>("FireStationId3")
                        .HasColumnType("int");

                    b.Property<DateOnly>("InspDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateOnly>("YearOfRegist")
                        .HasColumnType("date");

                    b.HasKey("CarRegist");

                    b.HasIndex("FireStationId");

                    b.HasIndex("FireStationId1");

                    b.HasIndex("FireStationId2");

                    b.HasIndex("FireStationId3");

                    b.ToTable("Vehicles", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EMS.services.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("EquipmentVehicle", b =>
                {
                    b.Property<int>("EquipmentsId")
                        .HasColumnType("int");

                    b.Property<string>("VehiclesCarRegist")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EquipmentsId", "VehiclesCarRegist");

                    b.HasIndex("VehiclesCarRegist");

                    b.ToTable("EquipmentVehicle");
                });

            modelBuilder.Entity("EventTeam", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("EventTeam");
                });

            modelBuilder.Entity("EventVehicle", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("EventVehicle");
                });

            modelBuilder.Entity("EMS.models.Events.CatastropheEvent", b =>
                {
                    b.HasBaseType("EMS.models.Events.Event");

                    b.Property<double>("AffectedArea")
                        .HasColumnType("float");

                    b.Property<int>("NumberOfVictims")
                        .HasColumnType("int");

                    b.Property<int>("TypeCat")
                        .HasColumnType("int");

                    b.ToTable("CatastropheEvent", (string)null);
                });

            modelBuilder.Entity("EMS.models.Events.FireEvent", b =>
                {
                    b.HasBaseType("EMS.models.Events.Event");

                    b.Property<double>("AffectedArea")
                        .HasColumnType("float");

                    b.Property<string>("FireIntensity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfFire")
                        .HasColumnType("int");

                    b.ToTable("FireEvent", (string)null);
                });

            modelBuilder.Entity("EMS.models.Events.MedicalEvent", b =>
                {
                    b.HasBaseType("EMS.models.Events.Event");

                    b.Property<int>("NumberOfVictims")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfEmergency")
                        .HasColumnType("int");

                    b.ToTable("MedicalEvent", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.Doctor", b =>
                {
                    b.HasBaseType("EMS.models.Persons.Person");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("FireStationId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.FireFighter", b =>
                {
                    b.HasBaseType("EMS.models.Persons.Person");

                    b.PrimitiveCollection<string>("Certifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.PrimitiveCollection<string>("Skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExp")
                        .HasColumnType("int");

                    b.HasIndex("FireStationId");

                    b.ToTable("FireFighters", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.Nurse", b =>
                {
                    b.HasBaseType("EMS.models.Persons.Person");

                    b.Property<string>("AreaOfActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.HasIndex("FireStationId");

                    b.ToTable("Nurses", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.Paramedic", b =>
                {
                    b.HasBaseType("EMS.models.Persons.Person");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<string>("TechnicalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("FireStationId");

                    b.ToTable("Paramedics", (string)null);
                });

            modelBuilder.Entity("EMS.models.Persons.Patient", b =>
                {
                    b.HasBaseType("EMS.models.Persons.Person");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FireStationId")
                        .HasColumnType("int");

                    b.Property<string>("MedicalRecordNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("FireStationId");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("EMS.models.Vehicles.Ambulance", b =>
                {
                    b.HasBaseType("EMS.models.Vehicles.Vehicle");

                    b.Property<int>("CrewCapacity")
                        .HasColumnType("int");

                    b.ToTable("Ambulances", (string)null);
                });

            modelBuilder.Entity("EMS.models.Vehicles.FireTruck", b =>
                {
                    b.HasBaseType("EMS.models.Vehicles.Vehicle");

                    b.Property<int>("CrewCapacity")
                        .HasColumnType("int");

                    b.Property<int>("WaterTankCapacity")
                        .HasColumnType("int");

                    b.ToTable("FireTrucks", (string)null);
                });

            modelBuilder.Entity("EMS.models.Vehicles.Helicopter", b =>
                {
                    b.HasBaseType("EMS.models.Vehicles.Vehicle");

                    b.Property<int>("CrewCapacity")
                        .HasColumnType("int");

                    b.Property<bool>("HasMedicalEquipment")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAltitude")
                        .HasColumnType("int");

                    b.Property<int>("MaxRange")
                        .HasColumnType("int");

                    b.ToTable("Helicopters", (string)null);
                });

            modelBuilder.Entity("EMS.models.Vehicles.MotorBike", b =>
                {
                    b.HasBaseType("EMS.models.Vehicles.Vehicle");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("int");

                    b.Property<bool>("HasFirstAidKit")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSiren")
                        .HasColumnType("bit");

                    b.ToTable("MotorBikes", (string)null);
                });

            modelBuilder.Entity("EMS.models.Equipments.Equipment", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Equipment")
                        .HasForeignKey("FireStationId");
                });

            modelBuilder.Entity("EMS.models.Persons.Person", b =>
                {
                    b.HasOne("EMS.models.Teams.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("EMS.models.Vehicles.Vehicle", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Ambulance")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("FireTrucks")
                        .HasForeignKey("FireStationId1");

                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Helicopter")
                        .HasForeignKey("FireStationId2");

                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("MotorBike")
                        .HasForeignKey("FireStationId3");
                });

            modelBuilder.Entity("EquipmentVehicle", b =>
                {
                    b.HasOne("EMS.models.Equipments.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesCarRegist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventTeam", b =>
                {
                    b.HasOne("EMS.models.Events.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.models.Teams.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventVehicle", b =>
                {
                    b.HasOne("EMS.models.Events.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Events.CatastropheEvent", b =>
                {
                    b.HasOne("EMS.models.Events.Event", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Events.CatastropheEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Events.FireEvent", b =>
                {
                    b.HasOne("EMS.models.Events.Event", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Events.FireEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Events.MedicalEvent", b =>
                {
                    b.HasOne("EMS.models.Events.Event", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Events.MedicalEvent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Persons.Doctor", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Doctors")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.Persons.Person", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Persons.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Persons.FireFighter", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("FireFighters")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.Persons.Person", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Persons.FireFighter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Persons.Nurse", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Nurses")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.Persons.Person", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Persons.Nurse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Persons.Paramedic", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Paramedics")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.Persons.Person", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Persons.Paramedic", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Persons.Patient", b =>
                {
                    b.HasOne("EMS.models.FireStation", null)
                        .WithMany("Patients")
                        .HasForeignKey("FireStationId");

                    b.HasOne("EMS.models.Persons.Person", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Persons.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Vehicles.Ambulance", b =>
                {
                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Vehicles.Ambulance", "CarRegist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Vehicles.FireTruck", b =>
                {
                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Vehicles.FireTruck", "CarRegist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Vehicles.Helicopter", b =>
                {
                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Vehicles.Helicopter", "CarRegist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.Vehicles.MotorBike", b =>
                {
                    b.HasOne("EMS.models.Vehicles.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("EMS.models.Vehicles.MotorBike", "CarRegist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EMS.models.FireStation", b =>
                {
                    b.Navigation("Ambulance");

                    b.Navigation("Doctors");

                    b.Navigation("Equipment");

                    b.Navigation("FireFighters");

                    b.Navigation("FireTrucks");

                    b.Navigation("Helicopter");

                    b.Navigation("MotorBike");

                    b.Navigation("Nurses");

                    b.Navigation("Paramedics");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("EMS.models.Teams.Team", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
