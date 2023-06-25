using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        private readonly IDbService _dbService;
        private readonly ILogger<JournalEntryService> _logger;

        private IConfiguration _configuration;

        public JournalEntryService(IDbService dbService, ILogger<JournalEntryService> logger
            , IConfiguration configuration)
        {
            _dbService = dbService;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task AddAsync(JournalEntry journalEntry)
        {
            try
            {
                await journalEntry.ConvertImagesToPathsAsync(_configuration.GetValue<string>("ImagesPath")!);
                _dbService.Context.Add(journalEntry);
                await _dbService.Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Adding of JournalEntry failed! {ex}", ex);
            }
        }

        public async Task<List<JournalEntry>> GetEntriesForTransferAsync()
        {
            try
            {
                var entries = await _dbService.Context.JournalEntries!.ToListAsync();
                entries.ForEach(async j => await j.ConvertPathsToImagesAsync());
                await _dbService.Context.SaveChangesAsync();
                return entries;
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval and conversion of JournalEntries failed! {ex}", ex);
            }
            throw new Exception("Error while converting JournalEntries!");
        }

        public async Task<List<JournalEntry>> GetEntriesAsync() => await _dbService.Context.JournalEntries.ToListAsync();

        public async Task<List<JournalEntry>> GetEntriesAsync(int startIndex = 0, int? endIndex = null)
        {
            try
            {
                var entries = await GetEntriesAsync();
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

        public async Task<JournalEntry?> FirstOrDefaultAsync(Func<JournalEntry, bool> predicate) => await _dbService.Context.JournalEntries.FirstOrDefaultAsync(j => predicate(j));

        public async Task<JournalEntry> FromIdAsync(int id)
        {
            try
            {
                var entry = await _dbService.Context.JournalEntries.FindAsync(id);
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
                _dbService.Context.JournalEntries.Remove(journalEntry);
                await _dbService.Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Removal of JournalEntry failed! {ex}", ex);
            }
        }

        public async Task UpdateEntryAsync(JournalEntry journalEntry)
        {
            _dbService.Context.Update(journalEntry);
            await _dbService.Context.SaveChangesAsync();
        }

        public async Task<bool> EntryExistsAsync(int id) => await _dbService.Context.JournalEntries.AnyAsync(e => e.Id == id);

        public bool IsTableExistent() => _dbService.Context.JournalEntries != null;


    }
}
