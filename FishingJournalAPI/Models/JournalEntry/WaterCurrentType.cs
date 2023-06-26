namespace FishingJournal.API.Models.JournalEntry
{
    public class WaterCurrentType : DbEntry<string>
    {
        public WaterCurrentType(int id, string value) : base(id, value) { }
    }
}
