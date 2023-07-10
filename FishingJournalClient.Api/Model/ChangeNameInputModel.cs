using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// ChangeNameInputModel
    /// </summary>
    [DataContract(Name = "ChangeNameInputModel")]
    public partial class ChangeNameInputModel : IEquatable<ChangeNameInputModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeNameInputModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChangeNameInputModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeNameInputModel" /> class.
        /// </summary>
        /// <param name="oldName">oldName (required).</param>
        /// <param name="newName">newName (required).</param>
        public ChangeNameInputModel(string oldName = default(string), string newName = default(string))
        {
            // to ensure "oldName" is required (not null)
            if (oldName == null)
            {
                throw new ArgumentNullException("oldName is a required property for ChangeNameInputModel and cannot be null");
            }
            this.OldName = oldName;
            // to ensure "newName" is required (not null)
            if (newName == null)
            {
                throw new ArgumentNullException("newName is a required property for ChangeNameInputModel and cannot be null");
            }
            this.NewName = newName;
        }
        /// <summary>
        /// Gets or Sets OldName
        /// </summary>
        [DataMember(Name = "oldName", IsRequired = true, EmitDefaultValue = true)]
        public string OldName { get; set; }
        /// <summary>
        /// Gets or Sets NewName
        /// </summary>
        [DataMember(Name = "newName", IsRequired = true, EmitDefaultValue = true)]
        public string NewName { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChangeNameInputModel {\n");
            sb.Append("  OldName: ").Append(OldName).Append("\n");
            sb.Append("  NewName: ").Append(NewName).Append("\n");
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
            return this.Equals(input as ChangeNameInputModel);
        }
        /// <summary>
        /// Returns true if ChangeNameInputModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ChangeNameInputModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChangeNameInputModel input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.OldName == input.OldName ||
                    (this.OldName != null &&
                    this.OldName.Equals(input.OldName))
                ) &&
                (
                    this.NewName == input.NewName ||
                    (this.NewName != null &&
                    this.NewName.Equals(input.NewName))
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
                if (this.OldName != null)
                {
                    hashCode = (hashCode * 59) + this.OldName.GetHashCode();
                }
                if (this.NewName != null)
                {
                    hashCode = (hashCode * 59) + this.NewName.GetHashCode();
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
            // OldName (string) minLength
            if (this.OldName != null && this.OldName.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OldName, length must be greater than 1.", new[] { "OldName" });
            }
            // NewName (string) minLength
            if (this.NewName != null && this.NewName.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for NewName, length must be greater than 1.", new[] { "NewName" });
            }
            yield break;
        }
    }
}
