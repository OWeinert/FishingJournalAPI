using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FishingJournal.Client.Api.Model
{
    /// <summary>
    /// EntryModificationInputModel
    /// </summary>
    [DataContract(Name = "EntryModificationInputModel")]
    public partial class EntryModificationInputModel : IEquatable<EntryModificationInputModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryModificationInputModel" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EntryModificationInputModel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryModificationInputModel" /> class.
        /// </summary>
        /// <param name="username">username (required).</param>
        /// <param name="journalEntryId">journalEntryId (required).</param>
        /// <param name="newJournalEntry">newJournalEntry.</param>
        public EntryModificationInputModel(string username = default(string), int journalEntryId = default(int), JournalEntry newJournalEntry = default(JournalEntry))
        {
            // to ensure "username" is required (not null)
            if (username == null)
            {
                throw new ArgumentNullException("username is a required property for EntryModificationInputModel and cannot be null");
            }
            this.Username = username;
            this.JournalEntryId = journalEntryId;
            this.NewJournalEntry = newJournalEntry;
        }
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name = "username", IsRequired = true, EmitDefaultValue = true)]
        public string Username { get; set; }
        /// <summary>
        /// Gets or Sets JournalEntryId
        /// </summary>
        [DataMember(Name = "journalEntryId", IsRequired = true, EmitDefaultValue = true)]
        public int JournalEntryId { get; set; }
        /// <summary>
        /// Gets or Sets NewJournalEntry
        /// </summary>
        [DataMember(Name = "newJournalEntry", EmitDefaultValue = true)]
        public JournalEntry NewJournalEntry { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntryModificationInputModel {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  JournalEntryId: ").Append(JournalEntryId).Append("\n");
            sb.Append("  NewJournalEntry: ").Append(NewJournalEntry).Append("\n");
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
            return this.Equals(input as EntryModificationInputModel);
        }
        /// <summary>
        /// Returns true if EntryModificationInputModel instances are equal
        /// </summary>
        /// <param name="input">Instance of EntryModificationInputModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntryModificationInputModel input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
                ) &&
                (
                    this.JournalEntryId == input.JournalEntryId ||
                    this.JournalEntryId.Equals(input.JournalEntryId)
                ) &&
                (
                    this.NewJournalEntry == input.NewJournalEntry ||
                    (this.NewJournalEntry != null &&
                    this.NewJournalEntry.Equals(input.NewJournalEntry))
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
                if (this.Username != null)
                {
                    hashCode = (hashCode * 59) + this.Username.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.JournalEntryId.GetHashCode();
                if (this.NewJournalEntry != null)
                {
                    hashCode = (hashCode * 59) + this.NewJournalEntry.GetHashCode();
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
            // Username (string) minLength
            if (this.Username != null && this.Username.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Username, length must be greater than 1.", new[] { "Username" });
            }
            yield break;
        }
    }
}
