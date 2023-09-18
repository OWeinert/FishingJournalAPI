using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Mapping
{
    public class ValueToDbEntryConverter<T, TDbEntry> : IValueConverter<T, TDbEntry> where TDbEntry : DbEntry<T, JournalEntry>
    {
        public TDbEntry Convert(T sourceMember, ResolutionContext context)
        {
            return (TDbEntry)Activator.CreateInstance(typeof(TDbEntry), sourceMember)!;
        }
    }
}
