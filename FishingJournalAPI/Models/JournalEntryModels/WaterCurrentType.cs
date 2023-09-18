namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// Current in the water body
    /// e.g. "still", "rapids", etc.
    /// </summary>
    public class WaterCurrentType : DbEntry<string, JournalEntry>
    {
        public WaterCurrentType(string? value) : base(value)
        {
        }
    }
}
