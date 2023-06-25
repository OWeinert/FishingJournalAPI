using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FishingJournal.API.Models
{
    /// <summary>
    /// Location consisting of a latitude and longitude value
    /// </summary>
    [DataContract]
    public struct Location
    {
        [DataMember]
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [DataMember]
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        public Location(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
