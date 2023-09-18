namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// Species of fish
    /// e.g. "common carp", "eel", "herring", etc.
    /// </summary>
    public class FishType : DbEntry<string, JournalEntry>
    {
        public FishType(string? value) : base(value) { }
    }
}
