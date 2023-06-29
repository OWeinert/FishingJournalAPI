namespace FishingJournal.API.Helpers
{
    public class IdGenerator
    {
        public const int DefaultLength = 8;
        public const string IdChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        public static string CreateId(int length)
        {
            var random = new Random();

            return new string(Enumerable.Repeat(IdChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
