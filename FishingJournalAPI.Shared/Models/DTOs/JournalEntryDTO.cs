#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.Text.Json.Serialization;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Models.DTOs
{
    public class JournalEntryDTO
    {
        /// <summary>
        /// Date and Time of catch
        /// </summary>
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("fishType")]
        public string FishType { get; set; }

        /// <summary>
        /// Fish length
        /// </summary>
        [JsonPropertyName("length")]
        public float Length { get; set; }

        /// <summary>
        /// Fish weight
        /// </summary>
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// Optional fish nickname
        /// </summary>
        [JsonPropertyName("fishNickname")]
        public string FishNickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("rigType")]
        public string RigType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hookType")]
        public string HookType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hookSize")]
        public string HookSize { get; set; }

        /// <summary>
        /// Additional info of what bait was used
        /// </summary>
        [JsonPropertyName("baitInfo")]
        public string BaitInfo { get; set; }

        /// <summary>
        /// Additional info of what feed was used
        /// </summary>
        [JsonPropertyName("hookInfo")]
        public string FeedInfo { get; set; }

        /// <summary>
        /// Duration of feeding in days before the catch day
        /// </summary>
        [JsonPropertyName("feedDuration")]
        public short FeedDuration { get; set; }

        /// <summary>
        /// Catch location latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// Catch location longitude
        /// </summary>
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Optional name of the catch location
        /// </summary>
        [JsonPropertyName("locationName")]
        public string LocationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("weatherType")]
        public string WeatherType { get; set; }

        /// <summary>
        /// Wind strength on the Beaufort scale
        /// </summary>
        [JsonPropertyName("windStrength")]
        public byte WindStrength { get; set; }

        /// <summary>
        /// Wind direction as cardinal direction
        /// </summary>
        [JsonPropertyName("windDirection")]
        public CardinalDirection WindDirection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("waterSurfaceType")]
        public string WaterSurfaceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("waterCurrentType")]
        public string WaterCurrentType { get; set; }

        /// <summary>
        /// Air pressure in mbar (1 mbar = 1 hPa = 100 Pa)
        /// </summary>
        [JsonPropertyName("airPressure")]
        public float AirPressure { get; set; }

        /// <summary>
        /// Tendency of the air pressure before the catch day
        /// </summary>
        [JsonPropertyName("airPressureTendency")]
        public AirPressureTendency AirPressureTendency { get; set; }

        [JsonPropertyName("airTemperature")]
        public float AirTemperature { get; set; }

        [JsonPropertyName("waterTemperature")]
        public float WaterTemperature { get; set; }

        /// <summary>
        /// Optional additional informations
        /// </summary>
        [JsonPropertyName("additionalInfo")]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("fishImage")]
        public byte[] FishImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("catchPlaceImage")]
        public byte[] CatchPlaceImage { get; set; }
    }
}
