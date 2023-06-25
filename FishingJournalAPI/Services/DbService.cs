using FishingJournal.API.Database;

namespace FishingJournal.API.Services
{
    public class DbService : IDbService
    {
        private FishingJournalDbContext _context;
        public FishingJournalDbContext Context => _context;

        public DbService(IConfiguration configuration)
        {
            _context = new FishingJournalDbContext(configuration);
        }
    }
}
