using FishingJournalClient.API.Models;
using Refit;

namespace FishingJournalClient.API.Endpoints;

public interface IJournalEntryApi
{
    const string BasePath = "/Entries";

    [Get(BasePath)]
    Task<List<JournalEntry>> GetAll();

    [Get($"{BasePath}/{{id}}")]
    Task<JournalEntry> GetById(int id);
    
    [Get($"{BasePath}/{{startIndex}}.{{endIndex?}}")]
    Task<JournalEntry> GetSlice(int startIndex, int? endIndex);
    
    [Get($"{BasePath}/User/name:{{username}}")]
    Task<JournalEntry> GetByUsername(string username);
    
    [Get($"{BasePath}/User/mail:{{email}}")]
    Task<JournalEntry> GetByEmail(string email);

    [Post($"{BasePath}/Add")]
    Task Add(JournalEntry journalEntry);

    [Put($"{BasePath}/Edit")]
    Task Edit(JournalEntry journalEntry);

    [Delete($"{BasePath}/Delete")]
    Task Delete(JournalEntry journalEntry);
}