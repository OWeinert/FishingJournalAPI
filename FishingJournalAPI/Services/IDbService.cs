using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Services
{
    public interface IDbService
    {
        public FishingJournalDbContext Context { get; }

        public Task<DbEntry<T>?> EntryFromIdAsync<T>(DbSet<DbEntry<T>> dbSet, int id);
    }
}
