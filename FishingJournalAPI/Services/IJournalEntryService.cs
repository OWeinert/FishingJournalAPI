using FishingJournal.API.Models;

namespace FishingJournal.API.Services
{
    public interface IJournalEntryService
    {
        /// <summary>
        /// Retrieves all JournalEntries and converts the Image paths 
        /// which are saved in the database into byte arrays for data transfer
        /// </summary>
        /// <returns></returns>
        public Task<List<JournalEntry>> TransformEntriesForTransportAsync();

        /// <summary>
        /// Retrieves all JournalEntries as a list
        /// </summary>
        /// <returns></returns>
        public Task<List<JournalEntry>> GetEntriesAsync();

        /// <summary>
        /// Retrieves a list of JournalEntries between the starting and end index
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public Task<List<JournalEntry>> GetEntriesAsync(int startIndex = 0, int? endIndex = null);

        /// <summary>
        /// Adds the given JournalEntry to the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        public Task AddAsync(JournalEntry journalEntry);

        /// <summary>
        /// Removes the given JournalEntry from the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        public Task RemoveAsync(JournalEntry journalEntry);

        /// <summary>
        /// Returns the first JournalEntry found that fulfills the given predicate or null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<JournalEntry?> FirstOrDefaultAsync(Func<JournalEntry, bool> predicate);

        /// <summary>
        /// Returns the JournalEntry of the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<JournalEntry> FromIdAsync(int id);

        /// <summary>
        /// Updates the given JournalEntry in the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        public Task UpdateEntryAsync(JournalEntry journalEntry);

        /// <summary>
        /// Checks if an entry with the given id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> EntryExistsAsync(int id);

        /// <summary>
        /// Checks if the JournalEntries table exists in the database
        /// </summary>
        /// <returns></returns>
        public bool IsTableExistent();
    }
}
