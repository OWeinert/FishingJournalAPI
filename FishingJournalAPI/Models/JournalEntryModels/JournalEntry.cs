using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace FishingJournal.API.Models.JournalEntryModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class JournalEntry
    {
        

        /// <summary>
        /// JournalEntry's Id in the database
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// User who created the JournalEntry
        /// </summary>
        [Required]
        public User User { get; set; }

        /// <summary>
        /// Id of the User
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        /// <summary>
        /// Date and Time of catch
        /// </summary>
        [Required]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// Catched species of fish
        /// </summary>
        [Required]
        public FishType? FishType { get; set; }

        [Required]
        [ForeignKey(nameof(FishType))]
        public int FishTypeId { get; set; }

        /// <summary>
        /// Fish length
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// Fish weight
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Optional fish nickname
        /// </summary>
        public string FishNickname { get; set; }


        /// <summary>
        /// The type of fishing rig used
        /// </summary>
        public RigType? RigType { get; set; }

        [ForeignKey(nameof(RigType))]
        public int RigTypeId { get; set; }

        /// <summary>
        /// The type of hook used
        /// </summary>
        public HookType? HookType { get; set; }

        [ForeignKey(nameof(HookType))]
        public int HookTypeId { get; set; }

        /// <summary>
        /// The size of hook used
        /// </summary>
        public HookSize? HookSize { get; set; }

        [ForeignKey(nameof(HookSize))]
        public int HookSizeId { get; set; }

        /// <summary>
        /// Additional info of what bait was used
        /// </summary>
        public string BaitInfo { get; set; }

        /// <summary>
        /// Additional info of what feed was used
        /// </summary>
        public string FeedInfo { get; set; }

        /// <summary>
        /// Duration of feeding in days before the catch day
        /// </summary>
        public short FeedDuration { get; set; }


        /// <summary>
        /// Catch location latitude
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Catch location longitude
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Optional name of the catch location
        /// </summary>
        public string LocationName { get; set; }


        /// <summary>
        /// The weather conditions at time of catch
        /// </summary>
        public WeatherType? WeatherType { get; set; }

        [ForeignKey(nameof(WeatherType))]
        public int WeatherTypeId { get; set; }

        /// <summary>
        /// Wind strength on the Beaufort scale
        /// </summary>
        public byte WindStrength { get; set; }

        /// <summary>
        /// Wind direction as cardinal direction
        /// </summary>
        public CardinalDirection WindDirection { get; set; }

        /// <summary>
        /// The constitution of the water surface at time of catch
        /// </summary>
        public WaterSurfaceType? WaterSurfaceType { get; set; }

        [ForeignKey(nameof(WaterSurfaceType))]
        public int WaterSurfaceTypeId { get; set; }

        /// <summary>
        /// The type of water current at the place of catch
        /// </summary>
        public WaterCurrentType? WaterCurrentType { get; set; }

        [ForeignKey(nameof(WaterCurrentType))]
        public int WaterCurrentTypeId { get; set; }

        /// <summary>
        /// Air pressure in mbar (1 mbar = 1 hPa = 100 Pa)
        /// </summary>
        public float AirPressure { get; set; }

        /// <summary>
        /// Tendency of the air pressure before the catch day
        /// </summary>
        public AirPressureTendency AirPressureTendency { get; set; }

        public float AirTemperature { get; set; }

        public float WaterTemperature { get; set; }

        /// <summary>
        /// Optional additional informations
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Path to the fish image located on the server
        /// Only saved in the database and not transferred between client and server
        /// </summary>
        public string FishImagePath { get; set; }

        /// <summary>
        /// Path to the catch place image located on the server
        /// Only saved in the database and not transferred between client and server
        /// </summary>
        public string CatchPlaceImagePath { get; set; }
    }
}
