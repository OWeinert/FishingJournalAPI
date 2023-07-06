using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingJournal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "JournalEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_UserId",
                table: "JournalEntries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Users_UserId",
                table: "JournalEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Users_UserId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_UserId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JournalEntries");
        }
    }
}
