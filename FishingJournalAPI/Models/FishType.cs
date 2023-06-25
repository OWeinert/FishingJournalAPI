namespace FishingJournal.API.Models
{
    public class FishType : DbEntry<string>
    {
        public FishType(int id, string value) : base(id, value) { }
    }
}
