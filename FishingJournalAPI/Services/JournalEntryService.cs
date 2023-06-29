using FishingJournal.API.Database;
using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Implementation of Implementation of <see cref="IJournalEntryService"/>
    /// </summary>
    public class JournalEntryService : IJournalEntryService
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly ILogger<JournalEntryService> _logger;

        private IConfiguration _configuration;

        public JournalEntryService(FishingJournalDbContext dbContext, ILogger<JournalEntryService> logger
            , IConfiguration configuration)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task AddAsync(JournalEntry journalEntry)
        {
            try
            {
                await journalEntry.ConvertImagesToPathsAsync(_configuration.GetValue<string>("ImagesPath")!);
                _dbContext.Add(journalEntry);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Adding of JournalEntry failed! {ex}", ex);
            }
        }

        public async Task<IList<JournalEntry>> TransformEntriesForTransportAsync()
        {
            try
            {
                var entries = await _dbContext.JournalEntries!.ToListAsync();
                entries.ForEach(async j => await j.ConvertPathsToImagesAsync());
                await _dbContext.SaveChangesAsync();
                return entries;
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval and conversion of JournalEntries failed! {ex}", ex);
            }
            throw new Exception("Error while converting JournalEntries!");
        }

        public async Task<IList<JournalEntry>> GetAllAsync() => await _dbContext.JournalEntries.ToListAsync();

        public async Task<IList<JournalEntry>> GetSpanAsync(int startIndex = 0, int? endIndex = null)
        {
            try
            {
                var entries = await GetAllAsync();
                endIndex ??= entries.Count;

                if (endIndex < startIndex)
                    throw new ArgumentOutOfRangeException(nameof(endIndex), $"endIndex [{endIndex}] has to be higher than startIndex [{startIndex}] !");

                return entries.Skip(startIndex).Take(((int)endIndex) - startIndex + 1).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Retrieval of JournalEntries failed! {ex}", ex);
            }
            throw new Exception("Error while querying JournalEntries!");
        }

        public async Task<IList<JournalEntry>> GetUserEntriesAsync(string userId)
        {
            try
            {
                return await _dbContext.JournalEntries.Where(j => j.UserId == userId).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("Retrieval of JournalEntries for User with Id  {id}  failed! {ex}", userId, ex);
            }
            throw new Exception("Error while querying JournalEntries!");
        }

        public async Task<JournalEntry?> FirstOrDefaultAsync(Func<JournalEntry, bool> predicate) => await _dbContext.JournalEntries.FirstOrDefaultAsync(j => predicate(j));

        public async Task<JournalEntry> FromIdAsync(int id)
        {
            try
            {
                var entry = await _dbContext.JournalEntries.FindAsync(id);
                if (entry == null)
                    throw new Exception("Could not find JournalEntry with given id!");
                return entry;
            }
            catch (Exception ex) 
            {
                _logger.LogError("Finding JournalEntry from id failed! {ex}", ex);
            }
            throw new Exception($"Error while finding JournalEntry with id {id}");
        }

        public async Task RemoveAsync(JournalEntry journalEntry)
        {
            try
            {
                _dbContext.JournalEntries.Remove(journalEntry);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Removal of JournalEntry failed! {ex}", ex);
            }
        }

        public async Task RemoveMultipleAsync(IEnumerable<JournalEntry> journalEntries)
        {
            try
            {
                _dbContext.JournalEntries.RemoveRange(journalEntries);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Removal of JournalEntries failed! {ex}", ex);
            }
        }

        public async Task UpdateEntryAsync(JournalEntry journalEntry, JournalEntry newJournalEntry)
        {
            journalEntry = newJournalEntry;
            _dbContext.Update(journalEntry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EntryExistsAsync(int id) => await _dbContext.JournalEntries.AnyAsync(e => e.Id == id);

        public bool IsTableExistent() => _dbContext.JournalEntries != null;


    }
}
