using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models
{
    public class DbEntry<T, D>
    {
        /// <summary>
        /// Id in the database
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Value saved at the Id
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// List of database table entries which reference this DbEntry
        /// </summary>
        public IList<D> Parents { get; set; }
    }
}
