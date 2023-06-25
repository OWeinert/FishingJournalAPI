namespace FishingJournal.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RawUser
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public RawUser(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
