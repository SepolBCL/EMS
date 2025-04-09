using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class EMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartEventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fire_Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fire_Station", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CatastropheEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AffectedArea = table.Column<double>(type: "float", nullable: false),
                    TypeCat = table.Column<int>(type: "int", nullable: false),
                    NumberOfVictims = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatastropheEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatastropheEvent_Event_Id",
                        column: x => x.Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TypeOfFire = table.Column<int>(type: "int", nullable: false),
                    FireIntensity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectedArea = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireEvent_Event_Id",
                        column: x => x.Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberOfVictims = table.Column<int>(type: "int", nullable: false),
                    TypeOfEmergency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalEvent_Event_Id",
                        column: x => x.Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MaintenanceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    CarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearOfRegist = table.Column<DateOnly>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true),
                    FireStationId1 = table.Column<int>(type: "int", nullable: true),
                    FireStationId2 = table.Column<int>(type: "int", nullable: true),
                    FireStationId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.CarRegist);
                    table.ForeignKey(
                        name: "FK_Vehicles_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_Fire_Station_FireStationId1",
                        column: x => x.FireStationId1,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_Fire_Station_FireStationId2",
                        column: x => x.FireStationId2,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_Fire_Station_FireStationId3",
                        column: x => x.FireStationId3,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventTeam",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTeam", x => new { x.EventId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_EventTeam_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    CarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CrewCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.CarRegist);
                    table.ForeignKey(
                        name: "FK_Ambulances_Vehicles_CarRegist",
                        column: x => x.CarRegist,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentVehicle",
                columns: table => new
                {
                    EquipmentsId = table.Column<int>(type: "int", nullable: false),
                    VehiclesCarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentVehicle", x => new { x.EquipmentsId, x.VehiclesCarRegist });
                    table.ForeignKey(
                        name: "FK_EquipmentVehicle_Equipments_EquipmentsId",
                        column: x => x.EquipmentsId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentVehicle_Vehicles_VehiclesCarRegist",
                        column: x => x.VehiclesCarRegist,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventVehicle",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVehicle", x => new { x.EventId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_EventVehicle_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireTrucks",
                columns: table => new
                {
                    CarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WaterTankCapacity = table.Column<int>(type: "int", nullable: false),
                    CrewCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrucks", x => x.CarRegist);
                    table.ForeignKey(
                        name: "FK_FireTrucks_Vehicles_CarRegist",
                        column: x => x.CarRegist,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helicopters",
                columns: table => new
                {
                    CarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxAltitude = table.Column<int>(type: "int", nullable: false),
                    MaxRange = table.Column<int>(type: "int", nullable: false),
                    HasMedicalEquipment = table.Column<bool>(type: "bit", nullable: false),
                    CrewCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helicopters", x => x.CarRegist);
                    table.ForeignKey(
                        name: "FK_Helicopters_Vehicles_CarRegist",
                        column: x => x.CarRegist,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorBikes",
                columns: table => new
                {
                    CarRegist = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EngineCapacity = table.Column<int>(type: "int", nullable: false),
                    HasSiren = table.Column<bool>(type: "bit", nullable: false),
                    HasFirstAidKit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorBikes", x => x.CarRegist);
                    table.ForeignKey(
                        name: "FK_MotorBikes_Vehicles_CarRegist",
                        column: x => x.CarRegist,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireFighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    YearsOfExp = table.Column<int>(type: "int", nullable: false),
                    Certifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireFighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireFighters_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FireFighters_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nurses_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paramedics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TechnicalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paramedics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paramedics_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paramedics_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FireStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Fire_Station_FireStationId",
                        column: x => x.FireStationId,
                        principalTable: "Fire_Station",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_FireStationId",
                table: "Doctors",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_FireStationId",
                table: "Equipments",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentVehicle_VehiclesCarRegist",
                table: "EquipmentVehicle",
                column: "VehiclesCarRegist");

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_TeamId",
                table: "EventTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_EventVehicle_VehicleId",
                table: "EventVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FireFighters_FireStationId",
                table: "FireFighters",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_FireStationId",
                table: "Nurses",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Paramedics_FireStationId",
                table: "Paramedics",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FireStationId",
                table: "Patients",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamId",
                table: "Persons",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FireStationId",
                table: "Vehicles",
                column: "FireStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FireStationId1",
                table: "Vehicles",
                column: "FireStationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FireStationId2",
                table: "Vehicles",
                column: "FireStationId2");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FireStationId3",
                table: "Vehicles",
                column: "FireStationId3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "CatastropheEvent");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "EquipmentVehicle");

            migrationBuilder.DropTable(
                name: "EventTeam");

            migrationBuilder.DropTable(
                name: "EventVehicle");

            migrationBuilder.DropTable(
                name: "FireEvent");

            migrationBuilder.DropTable(
                name: "FireFighters");

            migrationBuilder.DropTable(
                name: "FireTrucks");

            migrationBuilder.DropTable(
                name: "Helicopters");

            migrationBuilder.DropTable(
                name: "MedicalEvent");

            migrationBuilder.DropTable(
                name: "MotorBikes");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Paramedics");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Fire_Station");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
