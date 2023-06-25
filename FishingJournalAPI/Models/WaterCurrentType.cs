namespace FishingJournal.API.Models
{
    public class WaterCurrentType : DbEntry<string>
    {
        public WaterCurrentType(int id, string value) : base(id, value) { }
    }
}
