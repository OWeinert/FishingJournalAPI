using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// ChangePasswordInputModel
    /// </summary>
    [DataContract(Name = "ChangePasswordInputModel")]
    public partial class ChangePasswordInputModel : IEquatable<ChangePasswordInputModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordInputModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChangePasswordInputModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordInputModel" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="oldPassword">oldPassword (required).</param>
        /// <param name="newPassword">newPassword (required).</param>
        /// <param name="confirmedNewPassword">confirmedNewPassword (required).</param>
        public ChangePasswordInputModel(string name = default(string), string oldPassword = default(string), string newPassword = default(string), string confirmedNewPassword = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ChangePasswordInputModel and cannot be null");
            }
            this.Name = name;
            // to ensure "oldPassword" is required (not null)
            if (oldPassword == null)
            {
                throw new ArgumentNullException("oldPassword is a required property for ChangePasswordInputModel and cannot be null");
            }
            this.OldPassword = oldPassword;
            // to ensure "newPassword" is required (not null)
            if (newPassword == null)
            {
                throw new ArgumentNullException("newPassword is a required property for ChangePasswordInputModel and cannot be null");
            }
            this.NewPassword = newPassword;
            // to ensure "confirmedNewPassword" is required (not null)
            if (confirmedNewPassword == null)
            {
                throw new ArgumentNullException("confirmedNewPassword is a required property for ChangePasswordInputModel and cannot be null");
            }
            this.ConfirmedNewPassword = confirmedNewPassword;
        }
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets OldPassword
        /// </summary>
        [DataMember(Name = "oldPassword", IsRequired = true, EmitDefaultValue = true)]
        public string OldPassword { get; set; }
        /// <summary>
        /// Gets or Sets NewPassword
        /// </summary>
        [DataMember(Name = "newPassword", IsRequired = true, EmitDefaultValue = true)]
        public string NewPassword { get; set; }
        /// <summary>
        /// Gets or Sets ConfirmedNewPassword
        /// </summary>
        [DataMember(Name = "confirmedNewPassword", IsRequired = true, EmitDefaultValue = true)]
        public string ConfirmedNewPassword { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChangePasswordInputModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OldPassword: ").Append(OldPassword).Append("\n");
            sb.Append("  NewPassword: ").Append(NewPassword).Append("\n");
            sb.Append("  ConfirmedNewPassword: ").Append(ConfirmedNewPassword).Append("\n");
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
            return this.Equals(input as ChangePasswordInputModel);
        }
        /// <summary>
        /// Returns true if ChangePasswordInputModel instances are equal
        /// </summary>
        /// <param name="input">Instance of ChangePasswordInputModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChangePasswordInputModel input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.OldPassword == input.OldPassword ||
                    (this.OldPassword != null &&
                    this.OldPassword.Equals(input.OldPassword))
                ) &&
                (
                    this.NewPassword == input.NewPassword ||
                    (this.NewPassword != null &&
                    this.NewPassword.Equals(input.NewPassword))
                ) &&
                (
                    this.ConfirmedNewPassword == input.ConfirmedNewPassword ||
                    (this.ConfirmedNewPassword != null &&
                    this.ConfirmedNewPassword.Equals(input.ConfirmedNewPassword))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.OldPassword != null)
                {
                    hashCode = (hashCode * 59) + this.OldPassword.GetHashCode();
                }
                if (this.NewPassword != null)
                {
                    hashCode = (hashCode * 59) + this.NewPassword.GetHashCode();
                }
                if (this.ConfirmedNewPassword != null)
                {
                    hashCode = (hashCode * 59) + this.ConfirmedNewPassword.GetHashCode();
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
            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", new[] { "Name" });
            }
            // OldPassword (string) minLength
            if (this.OldPassword != null && this.OldPassword.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OldPassword, length must be greater than 1.", new[] { "OldPassword" });
            }
            // NewPassword (string) minLength
            if (this.NewPassword != null && this.NewPassword.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for NewPassword, length must be greater than 1.", new[] { "NewPassword" });
            }
            // ConfirmedNewPassword (string) minLength
            if (this.ConfirmedNewPassword != null && this.ConfirmedNewPassword.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ConfirmedNewPassword, length must be greater than 1.", new[] { "ConfirmedNewPassword" });
            }
            yield break;
        }
    }
}
