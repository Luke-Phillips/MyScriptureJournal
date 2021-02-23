using Microsoft.EntityFrameworkCore.Migrations;

namespace MyScriptureJournal.Migrations
{
    public partial class ScriptureJournalEntryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ScriptureJournalEntry",
                newName: "ScriptureJournalEntryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScriptureJournalEntryID",
                table: "ScriptureJournalEntry",
                newName: "ID");
        }
    }
}
