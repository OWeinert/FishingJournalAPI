using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
        /// User's hashed password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Salt of the hashed password
        /// </summary>
        [Required]
        public byte[] Salt { get; set; }

        /// <summary>
        /// The Role of the user
        /// </summary>
        public string Role { get; set; }
    }
}
