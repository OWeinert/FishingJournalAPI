using FishingJournal.API.Database;

namespace FishingJournal.API.Services
{
    public interface IDbService
    {
        public FishingJournalDbContext Context { get; }
    }
}
