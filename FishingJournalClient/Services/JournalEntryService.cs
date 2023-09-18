using FishingJournal.Client.Api;
using FishingJournal.Client.Api.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FishingJournal.Client.Services
{
    internal class JournalEntryService : IJournalEntryService
    {
        private ObservableCollection<JournalEntryDTO> _journalEntries = new();
        public ObservableCollection<JournalEntryDTO> JournalEntries => _journalEntries;

        private ObservableCollection<FishType> _fishTypes = new();
        public ObservableCollection<FishType> FishTypes => _fishTypes;

        private ObservableCollection<HookType> _hookTypes = new();
        public ObservableCollection<HookType> HookTypes => _hookTypes;

        private ObservableCollection<HookSize> _hookSizes = new();
        public ObservableCollection<HookSize> HookSizes => _hookSizes;

        private ObservableCollection<RigType> _rigTypes = new();
        public ObservableCollection<RigType> RigTypes => _rigTypes;

        private ObservableCollection<WeatherType> _weatherTypes = new();
        public ObservableCollection<WeatherType> WeatherTypes => _weatherTypes;

        private ObservableCollection<WaterCurrentType> _waterCurrentTypes = new();
        public ObservableCollection<WaterCurrentType> WaterCurrentTypes => _waterCurrentTypes;

        private ObservableCollection<WaterSurfaceType> _waterSurfaceTypes = new();
        public ObservableCollection<WaterSurfaceType> WaterSurfaceTypes => _waterSurfaceTypes;

        private readonly IUserService _userService;
        private readonly IAsynchronousClient _client;

        public JournalEntryService(IUserService userService, IAsynchronousClient client)
        {
            _userService = userService;
            _client = client;
        }

        public async Task FetchJournalEntriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task FetchJournalEntriesAsync(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public async Task FetchJournalEntryContents()
        {
            throw new NotImplementedException();
        }

        public async Task FetchUserJournalEntriesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task FetchUserJournalEntriesAsync(User user, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public async Task UploadEditedJournalEntry(JournalEntryDTO journalEntry)
        {
            throw new NotImplementedException();
        }

        public async Task UploadJournalEntry(JournalEntryDTO journalEntry)
        {
            throw new NotImplementedException();
        }
    }
}
