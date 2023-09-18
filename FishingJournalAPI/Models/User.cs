using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.AspNetCore.Identity;

namespace FishingJournal.API.Models
{
    public class User : IdentityUser
    {
        public List<JournalEntry> JournalEntries { get; set; } = new List<JournalEntry>();
    }
}
