using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtmTimeTables.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZtmVehicleArrivals");

            migrationBuilder.DropTable(
                name: "ZtmStops");

            migrationBuilder.DropTable(
                name: "ZtmVehicles");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StopId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStops_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStops_UserId",
                table: "UserStops",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStops");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "ZtmStops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZtmStops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZtmVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZtmVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZtmVehicleArrivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZtmStopId = table.Column<int>(type: "INTEGER", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZtmVehicleArrivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZtmVehicleArrivals_ZtmStops_ZtmStopId",
                        column: x => x.ZtmStopId,
                        principalTable: "ZtmStops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZtmVehicleArrivals_ZtmVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "ZtmVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZtmVehicleArrivals_VehicleId",
                table: "ZtmVehicleArrivals",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ZtmVehicleArrivals_ZtmStopId",
                table: "ZtmVehicleArrivals",
                column: "ZtmStopId");
        }
    }
}
