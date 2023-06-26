namespace FishingJournal.API.Models.JournalEntry.JournalEntry
{
    public class FishType : DbEntry<string>
    {
        public FishType(int id, string value) : base(id, value) { }
    }
}
