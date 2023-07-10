using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// WaterSurfaceType
    /// </summary>
    [DataContract(Name = "WaterSurfaceType")]
    public partial class WaterSurfaceType : IEquatable<WaterSurfaceType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaterSurfaceType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WaterSurfaceType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WaterSurfaceType" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="value">value.</param>
        /// <param name="parents">parents.</param>
        public WaterSurfaceType(int id = default(int), string value = default(string), List<JournalEntry> parents = default(List<JournalEntry>))
        {
            this.Id = id;
            this.Value = value;
            this.Parents = parents;
        }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = true)]
        public string Value { get; set; }
        /// <summary>
        /// Gets or Sets Parents
        /// </summary>
        [DataMember(Name = "parents", EmitDefaultValue = true)]
        public List<JournalEntry> Parents { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WaterSurfaceType {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Parents: ").Append(Parents).Append("\n");
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
            return this.Equals(input as WaterSurfaceType);
        }
        /// <summary>
        /// Returns true if WaterSurfaceType instances are equal
        /// </summary>
        /// <param name="input">Instance of WaterSurfaceType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WaterSurfaceType input)
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
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) &&
                (
                    this.Parents == input.Parents ||
                    this.Parents != null &&
                    input.Parents != null &&
                    this.Parents.SequenceEqual(input.Parents)
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
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                if (this.Parents != null)
                {
                    hashCode = (hashCode * 59) + this.Parents.GetHashCode();
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
