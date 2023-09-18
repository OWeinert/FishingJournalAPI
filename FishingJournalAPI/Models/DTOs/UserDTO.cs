using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
