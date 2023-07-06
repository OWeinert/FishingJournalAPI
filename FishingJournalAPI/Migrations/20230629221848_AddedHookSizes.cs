using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingJournal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedHookSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HookSizeId",
                table: "JournalEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HookSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HookSizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_HookSizeId",
                table: "JournalEntries",
                column: "HookSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_HookSizes_HookSizeId",
                table: "JournalEntries",
                column: "HookSizeId",
                principalTable: "HookSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_HookSizes_HookSizeId",
                table: "JournalEntries");

            migrationBuilder.DropTable(
                name: "HookSizes");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_HookSizeId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "HookSizeId",
                table: "JournalEntries");
        }
    }
}
