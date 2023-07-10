using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// JournalEntry
    /// </summary>
    [DataContract(Name = "JournalEntry")]
    public partial class JournalEntry : IEquatable<JournalEntry>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="JournalEntry" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JournalEntry() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntry" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="user">user (required).</param>
        /// <param name="userId">userId (required).</param>
        /// <param name="dateTime">dateTime (required).</param>
        /// <param name="fishType">fishType (required).</param>
        /// <param name="fishTypeId">fishTypeId (required).</param>
        /// <param name="length">length.</param>
        /// <param name="weight">weight.</param>
        /// <param name="fishNickname">fishNickname.</param>
        /// <param name="rigType">rigType.</param>
        /// <param name="rigTypeId">rigTypeId.</param>
        /// <param name="hookType">hookType.</param>
        /// <param name="hookTypeId">hookTypeId.</param>
        /// <param name="hookSize">hookSize.</param>
        /// <param name="hookSizeId">hookSizeId.</param>
        /// <param name="baitInfo">baitInfo.</param>
        /// <param name="feedInfo">feedInfo.</param>
        /// <param name="feedDuration">feedDuration.</param>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        /// <param name="locationName">locationName.</param>
        /// <param name="weatherType">weatherType.</param>
        /// <param name="weatherTypeId">weatherTypeId.</param>
        /// <param name="windStrength">windStrength.</param>
        /// <param name="windDirection">windDirection.</param>
        /// <param name="waterSurfaceType">waterSurfaceType.</param>
        /// <param name="waterSurfaceTypeId">waterSurfaceTypeId.</param>
        /// <param name="waterCurrentType">waterCurrentType.</param>
        /// <param name="waterCurrentTypeId">waterCurrentTypeId.</param>
        /// <param name="airPressure">airPressure.</param>
        /// <param name="airPressureTendency">airPressureTendency.</param>
        /// <param name="airTemperature">airTemperature.</param>
        /// <param name="waterTemperature">waterTemperature.</param>
        /// <param name="additionalInfo">additionalInfo.</param>
        /// <param name="fishImagePath">fishImagePath.</param>
        /// <param name="catchPlaceImagePath">catchPlaceImagePath.</param>
        public JournalEntry(int id = default(int), User user = default(User), string userId = default(string), DateTime dateTime = default(DateTime), FishType fishType = default(FishType), int fishTypeId = default(int), float length = default(float), float weight = default(float), string fishNickname = default(string), RigType rigType = default(RigType), int rigTypeId = default(int), HookType hookType = default(HookType), int hookTypeId = default(int), HookSize hookSize = default(HookSize), int hookSizeId = default(int), string baitInfo = default(string), string feedInfo = default(string), int feedDuration = default(int), float latitude = default(float), float longitude = default(float), string locationName = default(string), WeatherType weatherType = default(WeatherType), int weatherTypeId = default(int), int windStrength = default(int), CardinalDirection? windDirection = default(CardinalDirection?), WaterSurfaceType waterSurfaceType = default(WaterSurfaceType), int waterSurfaceTypeId = default(int), WaterCurrentType waterCurrentType = default(WaterCurrentType), int waterCurrentTypeId = default(int), float airPressure = default(float), AirPressureTendency? airPressureTendency = default(AirPressureTendency?), float airTemperature = default(float), float waterTemperature = default(float), string additionalInfo = default(string), string fishImagePath = default(string), string catchPlaceImagePath = default(string))
        {
            this.Id = id;
            // to ensure "user" is required (not null)
            if (user == null)
            {
                throw new ArgumentNullException("user is a required property for JournalEntry and cannot be null");
            }
            this.User = user;
            // to ensure "userId" is required (not null)
            if (userId == null)
            {
                throw new ArgumentNullException("userId is a required property for JournalEntry and cannot be null");
            }
            this.UserId = userId;
            this.DateTime = dateTime;
            // to ensure "fishType" is required (not null)
            if (fishType == null)
            {
                throw new ArgumentNullException("fishType is a required property for JournalEntry and cannot be null");
            }
            this.FishType = fishType;
            this.FishTypeId = fishTypeId;
            this.Length = length;
            this.Weight = weight;
            this.FishNickname = fishNickname;
            this.RigType = rigType;
            this.RigTypeId = rigTypeId;
            this.HookType = hookType;
            this.HookTypeId = hookTypeId;
            this.HookSize = hookSize;
            this.HookSizeId = hookSizeId;
            this.BaitInfo = baitInfo;
            this.FeedInfo = feedInfo;
            this.FeedDuration = feedDuration;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.LocationName = locationName;
            this.WeatherType = weatherType;
            this.WeatherTypeId = weatherTypeId;
            this.WindStrength = windStrength;
            this.WindDirection = windDirection;
            this.WaterSurfaceType = waterSurfaceType;
            this.WaterSurfaceTypeId = waterSurfaceTypeId;
            this.WaterCurrentType = waterCurrentType;
            this.WaterCurrentTypeId = waterCurrentTypeId;
            this.AirPressure = airPressure;
            this.AirPressureTendency = airPressureTendency;
            this.AirTemperature = airTemperature;
            this.WaterTemperature = waterTemperature;
            this.AdditionalInfo = additionalInfo;
            this.FishImagePath = fishImagePath;
            this.CatchPlaceImagePath = catchPlaceImagePath;
        }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", IsRequired = true, EmitDefaultValue = true)]
        public User User { get; set; }
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name = "userId", IsRequired = true, EmitDefaultValue = true)]
        public string UserId { get; set; }
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name = "dateTime", IsRequired = true, EmitDefaultValue = true)]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Gets or Sets FishType
        /// </summary>
        [DataMember(Name = "fishType", IsRequired = true, EmitDefaultValue = true)]
        public FishType FishType { get; set; }
        /// <summary>
        /// Gets or Sets FishTypeId
        /// </summary>
        [DataMember(Name = "fishTypeId", IsRequired = true, EmitDefaultValue = true)]
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
        /// Gets or Sets RigType
        /// </summary>
        [DataMember(Name = "rigType", EmitDefaultValue = true)]
        public RigType RigType { get; set; }
        /// <summary>
        /// Gets or Sets RigTypeId
        /// </summary>
        [DataMember(Name = "rigTypeId", EmitDefaultValue = true)]
        public int RigTypeId { get; set; }
        /// <summary>
        /// Gets or Sets HookType
        /// </summary>
        [DataMember(Name = "hookType", EmitDefaultValue = true)]
        public HookType HookType { get; set; }
        /// <summary>
        /// Gets or Sets HookTypeId
        /// </summary>
        [DataMember(Name = "hookTypeId", EmitDefaultValue = true)]
        public int HookTypeId { get; set; }
        /// <summary>
        /// Gets or Sets HookSize
        /// </summary>
        [DataMember(Name = "hookSize", EmitDefaultValue = true)]
        public HookSize HookSize { get; set; }
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
        /// Gets or Sets FeedInfo
        /// </summary>
        [DataMember(Name = "feedInfo", EmitDefaultValue = true)]
        public string FeedInfo { get; set; }
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
        /// Gets or Sets WeatherType
        /// </summary>
        [DataMember(Name = "weatherType", EmitDefaultValue = true)]
        public WeatherType WeatherType { get; set; }
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
        /// Gets or Sets WaterSurfaceType
        /// </summary>
        [DataMember(Name = "waterSurfaceType", EmitDefaultValue = true)]
        public WaterSurfaceType WaterSurfaceType { get; set; }
        /// <summary>
        /// Gets or Sets WaterSurfaceTypeId
        /// </summary>
        [DataMember(Name = "waterSurfaceTypeId", EmitDefaultValue = true)]
        public int WaterSurfaceTypeId { get; set; }
        /// <summary>
        /// Gets or Sets WaterCurrentType
        /// </summary>
        [DataMember(Name = "waterCurrentType", EmitDefaultValue = true)]
        public WaterCurrentType WaterCurrentType { get; set; }
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
        /// Gets or Sets FishImagePath
        /// </summary>
        [DataMember(Name = "fishImagePath", EmitDefaultValue = true)]
        public string FishImagePath { get; set; }
        /// <summary>
        /// Gets or Sets CatchPlaceImagePath
        /// </summary>
        [DataMember(Name = "catchPlaceImagePath", EmitDefaultValue = true)]
        public string CatchPlaceImagePath { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JournalEntry {\n");
            sb.Append("  Id: ").Append(Id).Append('\n');
            sb.Append("  User: ").Append(User).Append('\n');
            sb.Append("  UserId: ").Append(UserId).Append('\n');
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  FishType: ").Append(FishType).Append('\n');
            sb.Append("  FishTypeId: ").Append(FishTypeId).Append('\n');
            sb.Append("  Length: ").Append(Length).Append('\n');
            sb.Append("  Weight: ").Append(Weight).Append('\n');
            sb.Append("  FishNickname: ").Append(FishNickname).Append('\n');
            sb.Append("  RigType: ").Append(RigType).Append('\n');
            sb.Append("  RigTypeId: ").Append(RigTypeId).Append('\n');
            sb.Append("  HookType: ").Append(HookType).Append('\n');
            sb.Append("  HookTypeId: ").Append(HookTypeId).Append('\n');
            sb.Append("  HookSize: ").Append(HookSize).Append('\n');
            sb.Append("  HookSizeId: ").Append(HookSizeId).Append('\n');
            sb.Append("  BaitInfo: ").Append(BaitInfo).Append('\n');
            sb.Append("  FeedInfo: ").Append(FeedInfo).Append('\n');
            sb.Append("  FeedDuration: ").Append(FeedDuration).Append('\n');
            sb.Append("  Latitude: ").Append(Latitude).Append('\n');
            sb.Append("  Longitude: ").Append(Longitude).Append('\n');
            sb.Append("  LocationName: ").Append(LocationName).Append('\n');
            sb.Append("  WeatherType: ").Append(WeatherType).Append('\n');
            sb.Append("  WeatherTypeId: ").Append(WeatherTypeId).Append('\n');
            sb.Append("  WindStrength: ").Append(WindStrength).Append('\n');
            sb.Append("  WindDirection: ").Append(WindDirection).Append('\n');
            sb.Append("  WaterSurfaceType: ").Append(WaterSurfaceType).Append('\n');
            sb.Append("  WaterSurfaceTypeId: ").Append(WaterSurfaceTypeId).Append('\n');
            sb.Append("  WaterCurrentType: ").Append(WaterCurrentType).Append('\n');
            sb.Append("  WaterCurrentTypeId: ").Append(WaterCurrentTypeId).Append('\n');
            sb.Append("  AirPressure: ").Append(AirPressure).Append('\n');
            sb.Append("  AirPressureTendency: ").Append(AirPressureTendency).Append('\n');
            sb.Append("  AirTemperature: ").Append(AirTemperature).Append('\n');
            sb.Append("  WaterTemperature: ").Append(WaterTemperature).Append('\n');
            sb.Append("  AdditionalInfo: ").Append(AdditionalInfo).Append('\n');
            sb.Append("  FishImagePath: ").Append(FishImagePath).Append('\n');
            sb.Append("  CatchPlaceImagePath: ").Append(CatchPlaceImagePath).Append('\n');
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
            return this.Equals(input as JournalEntry);
        }
        /// <summary>
        /// Returns true if JournalEntry instances are equal
        /// </summary>
        /// <param name="input">Instance of JournalEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JournalEntry input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) &&
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
                ) &&
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) &&
                (
                    this.DateTime == input.DateTime ||
                    (this.DateTime != null &&
                    this.DateTime.Equals(input.DateTime))
                ) &&
                (
                    this.FishType == input.FishType ||
                    (this.FishType != null &&
                    this.FishType.Equals(input.FishType))
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
                    this.RigType == input.RigType ||
                    (this.RigType != null &&
                    this.RigType.Equals(input.RigType))
                ) &&
                (
                    this.RigTypeId == input.RigTypeId ||
                    this.RigTypeId.Equals(input.RigTypeId)
                ) &&
                (
                    this.HookType == input.HookType ||
                    (this.HookType != null &&
                    this.HookType.Equals(input.HookType))
                ) &&
                (
                    this.HookTypeId == input.HookTypeId ||
                    this.HookTypeId.Equals(input.HookTypeId)
                ) &&
                (
                    this.HookSize == input.HookSize ||
                    (this.HookSize != null &&
                    this.HookSize.Equals(input.HookSize))
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
                    this.FeedInfo == input.FeedInfo ||
                    (this.FeedInfo != null &&
                    this.FeedInfo.Equals(input.FeedInfo))
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
                    this.WeatherType == input.WeatherType ||
                    (this.WeatherType != null &&
                    this.WeatherType.Equals(input.WeatherType))
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
                    this.WaterSurfaceType == input.WaterSurfaceType ||
                    (this.WaterSurfaceType != null &&
                    this.WaterSurfaceType.Equals(input.WaterSurfaceType))
                ) &&
                (
                    this.WaterSurfaceTypeId == input.WaterSurfaceTypeId ||
                    this.WaterSurfaceTypeId.Equals(input.WaterSurfaceTypeId)
                ) &&
                (
                    this.WaterCurrentType == input.WaterCurrentType ||
                    (this.WaterCurrentType != null &&
                    this.WaterCurrentType.Equals(input.WaterCurrentType))
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
                    this.FishImagePath == input.FishImagePath ||
                    (this.FishImagePath != null &&
                    this.FishImagePath.Equals(input.FishImagePath))
                ) &&
                (
                    this.CatchPlaceImagePath == input.CatchPlaceImagePath ||
                    (this.CatchPlaceImagePath != null &&
                    this.CatchPlaceImagePath.Equals(input.CatchPlaceImagePath))
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
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.User != null)
                {
                    hashCode = (hashCode * 59) + this.User.GetHashCode();
                }
                if (this.UserId != null)
                {
                    hashCode = (hashCode * 59) + this.UserId.GetHashCode();
                }
                if (this.DateTime != null)
                {
                    hashCode = (hashCode * 59) + this.DateTime.GetHashCode();
                }
                if (this.FishType != null)
                {
                    hashCode = (hashCode * 59) + this.FishType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FishTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.Length.GetHashCode();
                hashCode = (hashCode * 59) + this.Weight.GetHashCode();
                if (this.FishNickname != null)
                {
                    hashCode = (hashCode * 59) + this.FishNickname.GetHashCode();
                }
                if (this.RigType != null)
                {
                    hashCode = (hashCode * 59) + this.RigType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RigTypeId.GetHashCode();
                if (this.HookType != null)
                {
                    hashCode = (hashCode * 59) + this.HookType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HookTypeId.GetHashCode();
                if (this.HookSize != null)
                {
                    hashCode = (hashCode * 59) + this.HookSize.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.HookSizeId.GetHashCode();
                if (this.BaitInfo != null)
                {
                    hashCode = (hashCode * 59) + this.BaitInfo.GetHashCode();
                }
                if (this.FeedInfo != null)
                {
                    hashCode = (hashCode * 59) + this.FeedInfo.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FeedDuration.GetHashCode();
                hashCode = (hashCode * 59) + this.Latitude.GetHashCode();
                hashCode = (hashCode * 59) + this.Longitude.GetHashCode();
                if (this.LocationName != null)
                {
                    hashCode = (hashCode * 59) + this.LocationName.GetHashCode();
                }
                if (this.WeatherType != null)
                {
                    hashCode = (hashCode * 59) + this.WeatherType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.WeatherTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.WindStrength.GetHashCode();
                hashCode = (hashCode * 59) + this.WindDirection.GetHashCode();
                if (this.WaterSurfaceType != null)
                {
                    hashCode = (hashCode * 59) + this.WaterSurfaceType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.WaterSurfaceTypeId.GetHashCode();
                if (this.WaterCurrentType != null)
                {
                    hashCode = (hashCode * 59) + this.WaterCurrentType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.WaterCurrentTypeId.GetHashCode();
                hashCode = (hashCode * 59) + this.AirPressure.GetHashCode();
                hashCode = (hashCode * 59) + this.AirPressureTendency.GetHashCode();
                hashCode = (hashCode * 59) + this.AirTemperature.GetHashCode();
                hashCode = (hashCode * 59) + this.WaterTemperature.GetHashCode();
                if (this.AdditionalInfo != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalInfo.GetHashCode();
                }
                if (this.FishImagePath != null)
                {
                    hashCode = (hashCode * 59) + this.FishImagePath.GetHashCode();
                }
                if (this.CatchPlaceImagePath != null)
                {
                    hashCode = (hashCode * 59) + this.CatchPlaceImagePath.GetHashCode();
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
            // UserId (string) minLength
            if (this.UserId != null && this.UserId.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for UserId, length must be greater than 1.", new[] { "UserId" });
            }
            yield break;
        }
    }
}
