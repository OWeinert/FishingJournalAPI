namespace FishingJournal.API.Models.JournalEntry
{
    public class WeatherType : DbEntry<string>
    {
        public WeatherType(int id, string value) : base(id, value) { }
    }
}
