using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models
{
    public class User
    {
        /// <summary>
        /// Database ID of the User
        /// </summary>
        [Key]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// The username
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// User's hashed and salted password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// The Role of the user
        /// </summary>
        public string Role { get; set; }
    }
}
