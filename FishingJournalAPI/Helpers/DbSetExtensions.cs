using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.DTOs;
using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Helpers
{
    public static class DbSetExtensions
    {
        public static async Task<List<ComponentDTO<V>>> ToDTOListAsync<T, V, P>(this DbSet<T> dbSet, IMapper mapper) where T : DbEntry<V, P>
        {
            var dbEntries = await dbSet.ToListAsync();
            var mappedEntries = dbEntries.ConvertAll(mapper.Map<ComponentDTO<V>>);
            return mappedEntries;
        }
    }
}
