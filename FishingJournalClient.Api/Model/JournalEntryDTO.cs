using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// JournalEntryDTO
    /// </summary>
    [DataContract(Name = "JournalEntryDTO")]
    public partial class JournalEntryDTO : IEquatable<JournalEntryDTO>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets WindDirection
        /// </summary>
        [DataMember(Name = "windDirection", EmitDefaultValue = true)]
        public CardinalDirection? WindDirection { get; set; }
        /// <summary>
        /// Gets or Sets AirPressureTendency
        /// </summary>
        [DataMember(Name = "airPressureTendency", EmitDefaultValue = true)]
        public AirPressureTendency? AirPressureTendency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntryDTO" /> class.
        /// </summary>
        /// <param name="dateTime">dateTime.</param>
        /// <param name="userId">userId.</param>
        /// <param name="fishTypeId">fishTypeId.</param>
        /// <param name="length">length.</param>
        /// <param name="weight">weight.</param>
        /// <param name="fishNickname">fishNickname.</param>
        /// <param name="rigTypeId">rigTypeId.</param>
        /// <param name="hookTypeId">hookTypeId.</param>
        /// <param name="hookSizeId">hookSizeId.</param>
        /// <param name="baitInfo">baitInfo.</param>
        /// <param name="hookInfo">hookInfo.</param>
        /// <param name="feedDuration">feedDuration.</param>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        /// <param name="locationName">locationName.</param>
        /// <param name="weatherTypeId">weatherTypeId.</param>
        /// <param name="windStrength">windStrength.</param>
        /// <param name="windDirection">windDirection.</param>
        /// <param name="waterSurfaceTypeId">waterSurfaceTypeId.</param>
        /// <param name="waterCurrentTypeId">waterCurrentTypeId.</param>
        /// <param name="airPressure">airPressure.</param>
        /// <param name="airPressureTendency">airPressureTendency.</param>
        /// <param name="airTemperature">airTemperature.</param>
        /// <param name="waterTemperature">waterTemperature.</param>
        /// <param name="additionalInfo">additionalInfo.</param>
        /// <param name="fishImage">fishImage.</param>
        /// <param name="catchPlaceImage">catchPlaceImage.</param>
        public JournalEntryDTO(DateTime dateTime = default(DateTime), string userId = default(string), int fishTypeId = default(int), float length = default(float), float weight = default(float), string fishNickname = default(string), int rigTypeId = default(int), int hookTypeId = default(int), int hookSizeId = default(int), string baitInfo = default(string), string hookInfo = default(string), int feedDuration = default(int), float latitude = default(float), float longitude = default(float), string locationName = default(string), int weatherTypeId = default(int), int windStrength = default(int), CardinalDirection? windDirection = default(CardinalDirection?), int waterSurfaceTypeId = default(int), int waterCurrentTypeId = default(int), float airPressure = default(float), AirPressureTendency? airPressureTendency = default(AirPressureTendency?), float airTemperature = default(float), float waterTemperature = default(float), string additionalInfo = default(string), byte[] fishImage = default(byte[]), byte[] catchPlaceImage = default(byte[]))
        {
            this.DateTime = dateTime;
            this.UserId = userId;
            this.FishTypeId = fishTypeId;
            this.Length = length;
            this.Weight = weight;
            this.FishNickname = fishNickname;
            this.RigTypeId = rigTypeId;
            this.HookTypeId = hookTypeId;
            this.HookSizeId = hookSizeId;
            this.BaitInfo = baitInfo;
            this.HookInfo = hookInfo;
            this.FeedDuration = feedDuration;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.LocationName = locationName;
            this.WeatherTypeId = weatherTypeId;
            this.WindStrength = windStrength;
            this.WindDirection = windDirection;
            this.WaterSurfaceTypeId = waterSurfaceTypeId;
            this.WaterCurrentTypeId = waterCurrentTypeId;
            this.AirPressure = airPressure;
            this.AirPressureTendency = airPressureTendency;
            this.AirTemperature = airTemperature;
            this.WaterTemperature = waterTemperature;
            this.AdditionalInfo = additionalInfo;
            this.FishImage = fishImage;
            this.CatchPlaceImage = catchPlaceImage;
        }
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name = "dateTime", EmitDefaultValue = true)]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = true)]
        public string UserId { get; set; }
        /// <summary>
        /// Gets or Sets FishTypeId
        /// </summary>
        [DataMember(Name = "fishTypeId", EmitDefaultValue = true)]
        public int FishTypeId { get; set; }
        /// <summary>
        /// Gets or Sets Length
        /// </summary>
        [DataMember(Name = "length", EmitDefaultValue = true)]
        public float Length { get; set; }
        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name = "weight", EmitDefaultValue = true)]
        public float Weight { get; set; }
        /// <summary>
        /// Gets or Sets FishNickname
        /// </summary>
        [DataMember(Name = "fishNickname", EmitDefaultValue = true)]
        public string FishNickname { get; set; }
        /// <summary>
        /// Gets or Sets RigTypeId
        /// </summary>
        [DataMember(Name = "rigTypeId", EmitDefaultValue = true)]
        public int RigTypeId { get; set; }
        /// <summary>
        /// Gets or Sets HookTypeId
        /// </summary>
        [DataMember(Name = "hookTypeId", EmitDefaultValue = true)]
        public int HookTypeId { get; set; }
        /// <summary>
        /// Gets or Sets HookSizeId
        /// </summary>
        [DataMember(Name = "hookSizeId", EmitDefaultValue = true)]
        public int HookSizeId { get; set; }
        /// <summary>
        /// Gets or Sets BaitInfo
        /// </summary>
        [DataMember(Name = "baitInfo", EmitDefaultValue = true)]
        public string BaitInfo { get; set; }
        /// <summary>
        /// Gets or Sets HookInfo
        /// </summary>
        [DataMember(Name = "hookInfo", EmitDefaultValue = true)]
        public string HookInfo { get; set; }
        /// <summary>
        /// Gets or Sets FeedDuration
        /// </summary>
        [DataMember(Name = "feedDuration", EmitDefaultValue = true)]
        public int FeedDuration { get; set; }
        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        [DataMember(Name = "latitude", EmitDefaultValue = true)]
        public float Latitude { get; set; }
        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        [DataMember(Name = "longitude", EmitDefaultValue = true)]
        public float Longitude { get; set; }
        /// <summary>
        /// Gets or Sets LocationName
        /// </summary>
        [DataMember(Name = "locationName", EmitDefaultValue = true)]
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or Sets WeatherTypeId
        /// </summary>
        [DataMember(Name = "weatherTypeId", EmitDefaultValue = true)]
        public int WeatherTypeId { get; set; }
        /// <summary>
        /// Gets or Sets WindStrength
        /// </summary>
        [DataMember(Name = "windStrength", EmitDefaultValue = true)]
        public int WindStrength { get; set; }
        /// <summary>
        /// Gets or Sets WaterSurfaceTypeId
        /// </summary>
        [DataMember(Name = "waterSurfaceTypeId", EmitDefaultValue = true)]
        public int WaterSurfaceTypeId { get; set; }
        /// <summary>
        /// Gets or Sets WaterCurrentTypeId
        /// </summary>
        [DataMember(Name = "waterCurrentTypeId", EmitDefaultValue = true)]
        public int WaterCurrentTypeId { get; set; }
        /// <summary>
        /// Gets or Sets AirPressure
        /// </summary>
        [DataMember(Name = "airPressure", EmitDefaultValue = true)]
        public float AirPressure { get; set; }
        /// <summary>
        /// Gets or Sets AirTemperature
        /// </summary>
        [DataMember(Name = "airTemperature", EmitDefaultValue = true)]
        public float AirTemperature { get; set; }
        /// <summary>
        /// Gets or Sets WaterTemperature
        /// </summary>
        [DataMember(Name = "waterTemperature", EmitDefaultValue = true)]
        public float WaterTemperature { get; set; }
        /// <summary>
        /// Gets or Sets AdditionalInfo
        /// </summary>
        [DataMember(Name = "additionalInfo", EmitDefaultValue = true)]
        public string AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or Sets FishImage
        /// </summary>
        [DataMember(Name = "fishImage", EmitDefaultValue = true)]
        public byte[] FishImage { get; set; }
        /// <summary>
        /// Gets or Sets CatchPlaceImage
        /// </summary>
        [DataMember(Name = "catchPlaceImage", EmitDefaultValue = true)]
        public byte[] CatchPlaceImage { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JournalEntryDTO {\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  FishTypeId: ").Append(FishTypeId).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  FishNickname: ").Append(FishNickname).Append("\n");
            sb.Append("  RigTypeId: ").Append(RigTypeId).Append("\n");
            sb.Append("  HookTypeId: ").Append(HookTypeId).Append("\n");
            sb.Append("  HookSizeId: ").Append(HookSizeId).Append("\n");
            sb.Append("  BaitInfo: ").Append(BaitInfo).Append("\n");
            sb.Append("  HookInfo: ").Append(HookInfo).Append("\n");
            sb.Append("  FeedDuration: ").Append(FeedDuration).Append("\n");
            sb.Append("  Latitude: ").Append(Latitude).Append("\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
            sb.Append("  LocationName: ").Append(LocationName).Append("\n");
            sb.Append("  WeatherTypeId: ").Append(WeatherTypeId).Append("\n");
            sb.Append("  WindStrength: ").Append(WindStrength).Append("\n");
            sb.Append("  WindDirection: ").Append(WindDirection).Append("\n");
            sb.Append("  WaterSurfaceTypeId: ").Append(WaterSurfaceTypeId).Append("\n");
            sb.Append("  WaterCurrentTypeId: ").Append(WaterCurrentTypeId).Append("\n");
            sb.Append("  AirPressure: ").Append(AirPressure).Append("\n");
            sb.Append("  AirPressureTendency: ").Append(AirPressureTendency).Append("\n");
            sb.Append("  AirTemperature: ").Append(AirTemperature).Append("\n");
            sb.Append("  WaterTemperature: ").Append(WaterTemperature).Append("\n");
            sb.Append("  AdditionalInfo: ").Append(AdditionalInfo).Append("\n");
            sb.Append("  FishImage: ").Append(FishImage).Append("\n");
            sb.Append("  CatchPlaceImage: ").Append(CatchPlaceImage).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as JournalEntryDTO);
        }
        /// <summary>
        /// Returns true if JournalEntryDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of JournalEntryDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JournalEntryDTO input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.DateTime == input.DateTime ||
                    (this.DateTime != null &&
                    this.DateTime.Equals(input.DateTime))
                ) &&
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) &&
                (
                    this.FishTypeId == input.FishTypeId ||
                    this.FishTypeId.Equals(input.FishTypeId)
                ) &&
                (
                    this.Length == input.Length ||
                    this.Length.Equals(input.Length)
                ) &&
                (
                    this.Weight == input.Weight ||
                    this.Weight.Equals(input.Weight)
                ) &&
                (
                    this.FishNickname == input.FishNickname ||
                    (this.FishNickname != null &&
                    this.FishNickname.Equals(input.FishNickname))
                ) &&
                (
                    this.RigTypeId == input.RigTypeId ||
                    this.RigTypeId.Equals(input.RigTypeId)
                ) &&
                (
                    this.HookTypeId == input.HookTypeId ||
                    this.HookTypeId.Equals(input.HookTypeId)
                ) &&
                (
                    this.HookSizeId == input.HookSizeId ||
                    this.HookSizeId.Equals(input.HookSizeId)
                ) &&
                (
                    this.BaitInfo == input.BaitInfo ||
                    (this.BaitInfo != null &&
                    this.BaitInfo.Equals(input.BaitInfo))
                ) &&
                (
                    this.HookInfo == input.HookInfo ||
                    (this.HookInfo != null &&
                    this.HookInfo.Equals(input.HookInfo))
                ) &&
                (
                    this.FeedDuration == input.FeedDuration ||
                    this.FeedDuration.Equals(input.FeedDuration)
                ) &&
                (
                    this.Latitude == input.Latitude ||
                    this.Latitude.Equals(input.Latitude)
                ) &&
                (
                    this.Longitude == input.Longitude ||
                    this.Longitude.Equals(input.Longitude)
                ) &&
                (
                    this.LocationName == input.LocationName ||
                    (this.LocationName != null &&
                    this.LocationName.Equals(input.LocationName))
                ) &&
                (
                    this.WeatherTypeId == input.WeatherTypeId ||
                    this.WeatherTypeId.Equals(input.WeatherTypeId)
                ) &&
                (
                    this.WindStrength == input.WindStrength ||
                    this.WindStrength.Equals(input.WindStrength)
                ) &&
                (
                    this.WindDirection == input.WindDirection ||
                    this.WindDirection.Equals(input.WindDirection)
                ) &&
                (
                    this.WaterSurfaceTypeId == input.WaterSurfaceTypeId ||
                    this.WaterSurfaceTypeId.Equals(input.WaterSurfaceTypeId)
                ) &&
                (
                    this.WaterCurrentTypeId == input.WaterCurrentTypeId ||
                    this.WaterCurrentTypeId.Equals(input.WaterCurrentTypeId)
                ) &&
                (
                    this.AirPressure == input.AirPressure ||
                    this.AirPressure.Equals(input.AirPressure)
                ) &&
                (
                    this.AirPressureTendency == input.AirPressureTendency ||
                    this.AirPressureTendency.Equals(input.AirPressureTendency)
                ) &&
                (
                    this.AirTemperature == input.AirTemperature ||
                    this.AirTemperature.Equals(input.AirTemperature)
                ) &&
                (
                    this.WaterTemperature == input.WaterTemperature ||
                    this.WaterTemperature.Equals(input.WaterTemperature)
                ) &&
                (
                    this.AdditionalInfo == input.AdditionalInfo ||
                    (this.AdditionalInfo != null &&
                    this.AdditionalInfo.Equals(input.AdditionalInfo))
                ) &&
                (
                    this.FishImage == input.FishImage ||
                    (this.FishImage != null &&
                    this.FishImage.Equals(input.FishImage))
                ) &&
                (
                    this.CatchPlaceImage == input.CatchPlaceImage ||
                    (this.CatchPlaceImage != null &&
                    this.CatchPlaceImage.Equals(input.CatchPlaceImage))
                );
        }
        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (this.DateTime != null)
                {
                    hashCode = (hashCode * 59) + this.DateTime.GetHashCode();
                }
                if (this.UserId != null)
                {
                    hashCode = (hashCode * 59) + this.UserId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FishTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.Length.GetHashCode();
                hashCode = (hashCode * 59) + this.Weight.GetHashCode();
                if (this.FishNickname != null)
                {
                    hashCode = (hashCode * 59) + this.FishNickname.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RigTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.HookTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.HookSizeId.GetHashCode();
                if (this.BaitInfo != null)
                {
                    hashCode = (hashCode * 59) + this.BaitInfo.GetHashCode();
                }
                if (this.HookInfo != null)
                {
                    hashCode = (hashCode * 59) + this.HookInfo.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FeedDuration.GetHashCode();
                hashCode = (hashCode * 59) + this.Latitude.GetHashCode();
                hashCode = (hashCode * 59) + this.Longitude.GetHashCode();
                if (this.LocationName != null)
                {
                    hashCode = (hashCode * 59) + this.LocationName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.WeatherTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.WindStrength.GetHashCode();
                hashCode = (hashCode * 59) + this.WindDirection.GetHashCode();
                hashCode = (hashCode * 59) + this.WaterSurfaceTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.WaterCurrentTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.AirPressure.GetHashCode();
                hashCode = (hashCode * 59) + this.AirPressureTendency.GetHashCode();
                hashCode = (hashCode * 59) + this.AirTemperature.GetHashCode();
                hashCode = (hashCode * 59) + this.WaterTemperature.GetHashCode();
                if (this.AdditionalInfo != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalInfo.GetHashCode();
                }
                if (this.FishImage != null)
                {
                    hashCode = (hashCode * 59) + this.FishImage.GetHashCode();
                }
                if (this.CatchPlaceImage != null)
                {
                    hashCode = (hashCode * 59) + this.CatchPlaceImage.GetHashCode();
                }
                return hashCode;
            }
        }
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
