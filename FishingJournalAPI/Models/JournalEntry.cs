using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FishingJournal.API.Models
{
    [DataContract]
    public class JournalEntry
    {
        /// <summary>
        /// JournalEntry's Id in the database
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Date and Time of catch
        /// </summary>
        [DataMember]
        [DataType(DataType.DateTime)]
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("fishType")]
        public FishType? FishType { get; set; }

        /// <summary>
        /// Fish length
        /// </summary>
        [DataMember]
        [JsonPropertyName("length")]
        public float Length { get; set; }

        /// <summary>
        /// Fish weight
        /// </summary>
        [DataMember]
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// Optional fish nickname
        /// </summary>
        [DataMember]
        [JsonPropertyName("fishNickname")]
        public string? FishNickname { get; set; }


        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("rigType")]
        public RigType? RigType { get; set; }

        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("hookType")]
        public HookType? HookType { get; set; }

        /// <summary>
        /// Additional info of what bait was used
        /// </summary>
        [DataMember]
        [JsonPropertyName("baitInfo")]
        public string? BaitInfo { get; set; }

        /// <summary>
        /// Additional info of what feed was used
        /// </summary>
        [DataMember]
        [JsonPropertyName("hookInfo")]
        public string? FeedInfo { get; set; }

        /// <summary>
        /// Duration of feeding in days before the catch day
        /// </summary>
        [DataMember]
        [JsonPropertyName("feedDuration")]
        public short FeedDuration { get; set; }


        /// <summary>
        /// Catch location given in latitude and longitude to support map tracking
        /// </summary>
        [NotMapped]
        [DataMember]
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        /// <summary>
        /// Optional name of the catch location
        /// </summary>
        [DataMember]
        [JsonPropertyName("locationName")]
        public string? LocationName { get; set; }


        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("weatherType")]
        public WeatherType? WeatherType { get; set; }

        /// <summary>
        /// Wind strength on the Beaufort scale
        /// </summary>
        [DataMember]
        [JsonPropertyName("windStrength")]
        public byte WindStrength { get; set; }

        /// <summary>
        /// Wind direction as cardinal direction
        /// </summary>
        [DataMember]
        [JsonPropertyName("windDirection")]
        public CardinalDirection WindDirection { get; set; }

        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("waterSurfaceType")]
        public WaterSurfaceType? WaterSurfaceType { get; set; }

        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("waterCurrentType")]
        public WaterCurrentType? WaterCurrentType { get; set; }

        /// <summary>
        /// Air pressure in mbar (1 mbar = 1 hPa = 100 Pa)
        /// </summary>
        [DataMember]
        [JsonPropertyName("airPressure")]
        public float AirPressure { get; set; }

        /// <summary>
        /// Tendency of the air pressure before the catch day
        /// </summary>
        [DataMember]
        [JsonPropertyName("airPressureTendency")]
        public AirPressureTendency AirPressureTendency { get; set; }

        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("airTemperature")]
        public float AirTemperature { get; set; }

        /// <summary>
        /// </summary>
        [DataMember]
        [JsonPropertyName("waterTemperature")]
        public float WaterTemperature { get; set; }


        /// <summary>
        /// Optional additional informations
        /// </summary>
        [DataMember]
        [JsonPropertyName("additionalInfo")]
        public string? AdditionalInfo { get; set; }


        /// <summary>
        /// Byte data of the fish image
        /// Only used for transferring the image between client and server
        /// </summary>
        [NotMapped]
        [DataMember]
        [JsonPropertyName("fishImage")]
        public byte[]? FishImage { get; set; }

        /// <summary>
        /// Path to the fish image located on the server
        /// Only saved in the database and not transferred between client and server
        /// </summary>
        public string? FishImagePath { get; set; }

        /// <summary>
        /// Byte data of the catch place image
        /// Only used for transferring the image between client and server
        /// </summary>
        [NotMapped]
        [DataMember]
        [JsonPropertyName("catchLocationImage")]
        public byte[]? CatchPlaceImage { get; set; }

        /// <summary>
        /// Path to the catch place image located on the server
        /// Only saved in the database and not transferred between client and server
        /// </summary>
        public string? CatchPlaceImagePath { get; set; }

    }
}
