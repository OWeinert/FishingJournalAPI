using System.Text.Json.Serialization;

namespace FishingJournal.API.Models.JournalEntryModels
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class ComponentContainer
    {
        [JsonPropertyName("fishTypes")]
        public List<FishType> FishTypes { get; set; }

        [JsonPropertyName("hookSizes")]
        public List<HookSize> HookSizes { get; set; }

        [JsonPropertyName("hookTypes")]
        public List<HookType> HookTypes { get; set; }

        [JsonPropertyName("rigTypes")]
        public List<RigType> RigTypes { get; set; }

        [JsonPropertyName("weatherTypes")]
        public List<WeatherType> WeatherTypes { get; set; }

        [JsonPropertyName("waterCurrentTypes")]
        public List<WaterCurrentType> WaterCurrentTypes { get; set; }

        [JsonPropertyName("waterSurfaceTypes")]
        public List<WaterSurfaceType> WaterSurfaceTypes { get; set; }
    }
}
