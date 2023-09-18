namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// The size of the hook
    /// e.g. "1", "0/2", "5"
    /// </summary>
    public class HookSize : DbEntry<string, JournalEntry>
    {
        public HookSize(string? value) : base(value)
        {
        }
    }
}
