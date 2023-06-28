using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models
{
    public class DbEntry<T, D>
    {
        [Required]
        public int Id { get; set; }

        public T? Value { get; set; }

        public IList<D> Parents { get; set; }
    }
}
