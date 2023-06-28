using FishingJournal.API.Models;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Services
{
    public interface IJournalEntryService
    {
        /// <summary>
        /// Returns all JournalEntries and converts the Image paths 
        /// which are saved in the database into byte arrays for data transfer
        /// </summary>
        /// <returns></returns>
        Task<IList<JournalEntry>> TransformEntriesForTransportAsync();

        /// <summary>
        /// Returns all JournalEntries as a list
        /// </summary>
        /// <returns></returns>
        Task<IList<JournalEntry>> GetAllAsync();

        /// <summary>
        /// Returns a list of JournalEntries between the starting and end index.
        /// DOES NOT RETURN A Span OBJECT!
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        Task<IList<JournalEntry>> GetSpanAsync(int startIndex = 0, int? endIndex = null);

        /// <summary>
        /// Returns all JournalEntries created by the specified User
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<IList<JournalEntry>> GetUserEntriesAsync(string userId);

        /// <summary>
        /// Adds the given JournalEntry to the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        Task AddAsync(JournalEntry journalEntry);

        /// <summary>
        /// Removes the given JournalEntry from the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        Task RemoveAsync(JournalEntry journalEntry);

        /// <summary>
        /// Removes multiple JournalEntries at once
        /// </summary>
        /// <param name="journalEntries"></param>
        /// <returns></returns>
        Task RemoveMultipleAsync(IEnumerable<JournalEntry> journalEntries);

        /// <summary>
        /// Returns the first JournalEntry found that fulfills the given predicate or null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<JournalEntry?> FirstOrDefaultAsync(Func<JournalEntry, bool> predicate);

        /// <summary>
        /// Returns the JournalEntry of the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JournalEntry> FromIdAsync(int id);

        /// <summary>
        /// Updates the given JournalEntry in the database
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        Task UpdateEntryAsync(JournalEntry journalEntry, JournalEntry newJournalEntry);

        /// <summary>
        /// Checks if an entry with the given id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> EntryExistsAsync(int id);

        /// <summary>
        /// Checks if the JournalEntries table exists in the database
        /// </summary>
        /// <returns></returns>
        bool IsTableExistent();
    }
}
