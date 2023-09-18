namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// Type of hook
    /// e.g. "curve shank", "choddy", "offset hook", etc.
    /// </summary>
    public class HookType : DbEntry<string, JournalEntry>
    {
        public HookType(string? value) : base(value)
        {
        }
    }
}
