using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FishingJournal.API.Models
{
    [PrimaryKey(nameof(Id), nameof(Name))]
    public class User
    {
        /// <summary>
        /// Database ID of the User
        /// </summary>
        [Required]
        public int Id { get; set; }
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
        /// Creates a new User 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        public User(string name, string password, byte[] salt)
        {
            Name = name;
            Password = password;
            Salt = salt;
        }
    }
}
