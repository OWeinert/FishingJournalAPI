using FishingJournal.API.Models.JournalEntryModels;
using System.ComponentModel.DataAnnotations;

namespace FishingJournal.API.Models.InputModels
{
    public class EntryModificationInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int JournalEntryId { get; set; }

        public JournalEntry? NewJournalEntry { get; set; }
    }
}
