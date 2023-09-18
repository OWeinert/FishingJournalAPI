using FishingJournal.API.Models.DTOs;
using System.Text.Json.Serialization;

namespace FishingJournal.API.Models.JournalEntryModels
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class ComponentContainer
    {
        [JsonPropertyName("fishTypes")]
        public List<ComponentDTO<string>> FishTypes { get; set; }

        [JsonPropertyName("hookSizes")]
        public List<ComponentDTO<string>> HookSizes { get; set; }

        [JsonPropertyName("hookTypes")]
        public List<ComponentDTO<string>> HookTypes { get; set; }

        [JsonPropertyName("rigTypes")]
        public List<ComponentDTO<string>> RigTypes { get; set; }

        [JsonPropertyName("weatherTypes")]
        public List<ComponentDTO<string>> WeatherTypes { get; set; }

        [JsonPropertyName("waterCurrentTypes")]
        public List<ComponentDTO<string>> WaterCurrentTypes { get; set; }

        [JsonPropertyName("waterSurfaceTypes")]
        public List<ComponentDTO<string>> WaterSurfaceTypes { get; set; }
    }
}
