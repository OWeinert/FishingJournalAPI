namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// Constitution of the water surface
    /// e.g. "still", "slight waves", etc.
    /// </summary>
    public class WaterSurfaceType : DbEntry<string, JournalEntry>
    {
        public WaterSurfaceType(string? value) : base(value)
        {
        }
    }
}
