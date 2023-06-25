namespace FishingJournal.API.Models
{
    public class RigType : DbEntry<string>
    {
        public RigType(int id, string value) : base(id, value) { }
    }
}
