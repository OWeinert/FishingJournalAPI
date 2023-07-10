using FishingJournal.Client.Api.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FishingJournal.Client.Services
{
    public interface IJournalEntryService
    {
        ObservableCollection<JournalEntryDTO> JournalEntries { get; }
        ObservableCollection<FishType> FishTypes { get; }
        ObservableCollection<HookType> HookTypes { get; }
        ObservableCollection<HookSize> HookSizes { get; }
        ObservableCollection<RigType> RigTypes { get; }
        ObservableCollection<WeatherType> WeatherTypes { get; }
        ObservableCollection<WaterCurrentType> WaterCurrentTypes { get; }
        ObservableCollection<WaterSurfaceType> WaterSurfaceTypes { get; }

        Task FetchJournalEntriesAsync();

        Task FetchJournalEntriesAsync(int startIndex, int endIndex);

        Task FetchUserJournalEntriesAsync(User user);

        Task FetchUserJournalEntriesAsync(User user, int startIndex, int endIndex);

        Task UploadJournalEntry(JournalEntryDTO journalEntry);

        Task UploadEditedJournalEntry(JournalEntryDTO journalEntry);

        Task FetchJournalEntryContents();

    }
}
