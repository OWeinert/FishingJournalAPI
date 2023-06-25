using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingJournal.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FishTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    FishNickname = table.Column<string>(type: "TEXT", nullable: true),
                    RigTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    HookTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BaitInfo = table.Column<string>(type: "TEXT", nullable: true),
                    FeedInfo = table.Column<string>(type: "TEXT", nullable: true),
                    FeedDuration = table.Column<short>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    WindStrength = table.Column<byte>(type: "INTEGER", nullable: false),
                    WindDirection = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterSurfaceTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterCurrentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    AirPressure = table.Column<float>(type: "REAL", nullable: false),
                    AirPressureTendency = table.Column<int>(type: "INTEGER", nullable: false),
                    AirTemperature = table.Column<float>(type: "REAL", nullable: false),
                    WaterTemperature = table.Column<float>(type: "REAL", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: true),
                    FishImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    CatchPlaceImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RigTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RigTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.Id, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "WaterCurrentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterCurrentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterSurfaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterSurfaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishTypes");

            migrationBuilder.DropTable(
                name: "HookTypes");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "RigTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaterCurrentTypes");

            migrationBuilder.DropTable(
                name: "WaterSurfaceTypes");

            migrationBuilder.DropTable(
                name: "WeatherTypes");
        }
    }
}
