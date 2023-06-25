namespace FishingJournal.API.Models
{
    public class HookType : DbEntry<string>
    {
        public HookType(int id, string value) : base(id, value) { }
    }
}
