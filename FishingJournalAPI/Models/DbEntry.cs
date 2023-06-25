using System.ComponentModel.DataAnnotations;

namespace FishingJournal.API.Models
{
    public class DbEntry<T>
    {
        [Required]
        public int Id { get; set; }

        public T? Value { get; set; }

        public DbEntry(int id, T value) 
        {
            Id = id;
            Value = value;
        }
    }
}
