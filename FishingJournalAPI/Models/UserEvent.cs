using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models
{    
    [PrimaryKey(nameof(UserId), nameof(EventId))]
    public class UserEvent
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }


        [ForeignKey(nameof(Event))]
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
