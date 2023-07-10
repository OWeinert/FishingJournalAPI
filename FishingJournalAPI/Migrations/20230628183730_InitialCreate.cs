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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    Latitude = table.Column<float>(type: "REAL", nullable: false),
                    Longitude = table.Column<float>(type: "REAL", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_JournalEntries_FishTypes_FishTypeId",
                        column: x => x.FishTypeId,
                        principalTable: "FishTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_HookTypes_HookTypeId",
                        column: x => x.HookTypeId,
                        principalTable: "HookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_RigTypes_RigTypeId",
                        column: x => x.RigTypeId,
                        principalTable: "RigTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_WaterCurrentTypes_WaterCurrentTypeId",
                        column: x => x.WaterCurrentTypeId,
                        principalTable: "WaterCurrentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_WaterSurfaceTypes_WaterSurfaceTypeId",
                        column: x => x.WaterSurfaceTypeId,
                        principalTable: "WaterSurfaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntries_WeatherTypes_WeatherTypeId",
                        column: x => x.WeatherTypeId,
                        principalTable: "WeatherTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_FishTypeId",
                table: "JournalEntries",
                column: "FishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_HookTypeId",
                table: "JournalEntries",
                column: "HookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_RigTypeId",
                table: "JournalEntries",
                column: "RigTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_WaterCurrentTypeId",
                table: "JournalEntries",
                column: "WaterCurrentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_WaterSurfaceTypeId",
                table: "JournalEntries",
                column: "WaterSurfaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_WeatherTypeId",
                table: "JournalEntries",
                column: "WeatherTypeId");

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
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FishTypes");

            migrationBuilder.DropTable(
                name: "HookTypes");

            migrationBuilder.DropTable(
                name: "RigTypes");

            migrationBuilder.DropTable(
                name: "WaterCurrentTypes");

            migrationBuilder.DropTable(
                name: "WaterSurfaceTypes");

            migrationBuilder.DropTable(
                name: "WeatherTypes");
        }
    }
}
