using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// User
    /// </summary>
    [DataContract(Name = "User")]
    public partial class User : IEquatable<User>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected User() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="password">password (required).</param>
        /// <param name="role">role.</param>
        public User(string id = default(string), string name = default(string), string password = default(string), string role = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for User and cannot be null");
            }
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for User and cannot be null");
            }
            this.Name = name;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for User and cannot be null");
            }
            this.Password = password;
            this.Role = role;
        }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }
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
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = true)]
        public string Role { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
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
            return this.Equals(input as User);
        }
        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="input">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) &&
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
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Password != null)
                {
                    hashCode = (hashCode * 59) + this.Password.GetHashCode();
                }
                if (this.Role != null)
                {
                    hashCode = (hashCode * 59) + this.Role.GetHashCode();
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
            // Id (string) minLength
            if (this.Id != null && this.Id.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, length must be greater than 1.", new[] { "Id" });
            }
            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 32.", new[] { "Name" });
            }
            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 0.", new[] { "Name" });
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
