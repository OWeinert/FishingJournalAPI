using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// RegisterInputModel
    /// </summary>
    [DataContract(Name = "RegisterInputModel")]
    public partial class RegisterInputModel : IEquatable<RegisterInputModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterInputModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RegisterInputModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterInputModel" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="password">password (required).</param>
        /// <param name="confirmedPassword">confirmedPassword (required).</param>
        public RegisterInputModel(string name = default(string), string password = default(string), string confirmedPassword = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for RegisterInputModel and cannot be null");
            }
            this.Name = name;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for RegisterInputModel and cannot be null");
            }
            this.Password = password;
            // to ensure "confirmedPassword" is required (not null)
            if (confirmedPassword == null)
            {
                throw new ArgumentNullException("confirmedPassword is a required property for RegisterInputModel and cannot be null");
            }
            this.ConfirmedPassword = confirmedPassword;
        }
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string Password { get; set; }
        /// <summary>
        /// Gets or Sets ConfirmedPassword
        /// </summary>
        [DataMember(Name = "confirmedPassword", IsRequired = true, EmitDefaultValue = true)]
        public string ConfirmedPassword { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RegisterInputModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  ConfirmedPassword: ").Append(ConfirmedPassword).Append("\n");
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
            return this.Equals(input as RegisterInputModel);
        }
        /// <summary>
        /// Returns true if RegisterInputModel instances are equal
        /// </summary>
        /// <param name="input">Instance of RegisterInputModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegisterInputModel input)
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
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) &&
                (
                    this.ConfirmedPassword == input.ConfirmedPassword ||
                    (this.ConfirmedPassword != null &&
                    this.ConfirmedPassword.Equals(input.ConfirmedPassword))
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
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                if (this.ConfirmedPassword != null)
                {
                    hashCode = (hashCode * 59) + this.ConfirmedPassword.GetHashCode();
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
            // Password (string) minLength
            if (this.Password != null && this.Password.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Password, length must be greater than 1.", new[] { "Password" });
            }
            // ConfirmedPassword (string) minLength
            if (this.ConfirmedPassword != null && this.ConfirmedPassword.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ConfirmedPassword, length must be greater than 1.", new[] { "ConfirmedPassword" });
            }
            yield break;
        }
    }
}
