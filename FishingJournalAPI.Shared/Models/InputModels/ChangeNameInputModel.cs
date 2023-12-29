using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models.InputModels
{
    public class ChangeNameInputModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string OldName { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}
