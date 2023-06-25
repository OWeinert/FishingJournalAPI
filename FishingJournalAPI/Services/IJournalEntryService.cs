using FishingJournal.API.Models;

namespace FishingJournal.API.Services
{
    public interface IJournalEntryService
    {
        public Task<List<JournalEntry>> GetEntriesForTransferAsync();

        public Task<List<JournalEntry>> GetEntriesAsync();

        public Task<List<JournalEntry>> GetEntriesAsync(int startIndex = 0, int? endIndex = null);

        public Task AddAsync(JournalEntry journalEntry);

        public Task RemoveAsync(JournalEntry journalEntry);

        public Task<JournalEntry?> FirstOrDefaultAsync(Func<JournalEntry, bool> predicate);

        public Task<JournalEntry> FromIdAsync(int id);

        public Task UpdateEntryAsync(JournalEntry journalEntry);

        public Task<bool> EntryExistsAsync(int id);

        public bool IsTableExistent();
    }
}
