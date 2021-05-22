using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myPennyFarthing.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "myPennyFarthing");

            migrationBuilder.CreateTable(
                name: "Bike",
                schema: "myPennyFarthing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "myPennyFarthing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                schema: "myPennyFarthing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<float>(type: "float(7)", nullable: false),
                    Cost = table.Column<float>(type: "float(7)", nullable: false),
                    BikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Bike_BikeId",
                        column: x => x.BikeId,
                        principalSchema: "myPennyFarthing",
                        principalTable: "Bike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                schema: "myPennyFarthing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<float>(type: "float(5)", nullable: false),
                    AvgCadence = table.Column<float>(type: "real", nullable: false),
                    AvgHR = table.Column<int>(type: "int", nullable: false),
                    AvgSpeed = table.Column<float>(type: "float(3)", nullable: false),
                    Ascent = table.Column<int>(type: "int", nullable: false),
                    Descent = table.Column<int>(type: "int", nullable: false),
                    HighGrade = table.Column<float>(type: "float(3)", nullable: false),
                    LowGrade = table.Column<float>(type: "float(3)", nullable: false),
                    BikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_Bike_BikeId",
                        column: x => x.BikeId,
                        principalSchema: "myPennyFarthing",
                        principalTable: "Bike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_BikeId",
                schema: "myPennyFarthing",
                table: "Maintenance",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_BikeId",
                schema: "myPennyFarthing",
                table: "Ride",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "myPennyFarthing",
                table: "User",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance",
                schema: "myPennyFarthing");

            migrationBuilder.DropTable(
                name: "Ride",
                schema: "myPennyFarthing");

            migrationBuilder.DropTable(
                name: "User",
                schema: "myPennyFarthing");

            migrationBuilder.DropTable(
                name: "Bike",
                schema: "myPennyFarthing");
        }
    }
}
