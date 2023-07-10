using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// LoginInputModel
    /// </summary>
    [DataContract(Name = "LoginInputModel")]
    public partial class LoginInputModel : IEquatable<LoginInputModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginInputModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LoginInputModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginInputModel" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="password">password (required).</param>
        public LoginInputModel(string name = default(string), string password = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for LoginInputModel and cannot be null");
            }
            this.Name = name;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for LoginInputModel and cannot be null");
            }
            this.Password = password;
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoginInputModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
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
            return this.Equals(input as LoginInputModel);
        }
        /// <summary>
        /// Returns true if LoginInputModel instances are equal
        /// </summary>
        /// <param name="input">Instance of LoginInputModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LoginInputModel input)
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
            yield break;
        }
    }
}
