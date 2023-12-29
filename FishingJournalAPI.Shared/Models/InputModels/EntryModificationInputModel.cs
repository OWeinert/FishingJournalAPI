using FishingJournal.API.Models.DTOs;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models.InputModels
{
    public class EntryModificationInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int JournalEntryId { get; set; }

        public JournalEntryDTO? NewJournalEntry { get; set; }
    }
}
