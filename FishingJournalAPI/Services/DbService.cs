using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Services
{
    public class DbService : IDbService
    {
        private readonly FishingJournalDbContext _context;
        public FishingJournalDbContext Context => _context;

        public DbService(IConfiguration configuration)
        {
            _context = new FishingJournalDbContext(configuration);
        }

        public async Task<DbEntry<T>?> EntryFromIdAsync<T>(DbSet<DbEntry<T>> dbSet, int id) => await dbSet.FindAsync(id);
    }
}
