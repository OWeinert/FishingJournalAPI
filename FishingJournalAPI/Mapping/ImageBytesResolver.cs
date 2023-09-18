using AutoMapper;
using FishingJournal.API.Models.DTOs;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageBytesResolver : IMemberValueResolver<JournalEntryDTO, JournalEntry, byte[], string>
    {
        private readonly IConfiguration _configuration;

        public ImageBytesResolver(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string Resolve(JournalEntryDTO source, JournalEntry destination, byte[] sourceMember, string destMember, ResolutionContext context)
        {
            using var ms = new MemoryStream(sourceMember);

            var image = Image.Load(ms);

            var confPath = _configuration.GetValue<string>("ImagesPath");
            var basePath = !string.IsNullOrWhiteSpace(confPath) ? confPath : Program.DefaultImagePath;
            var imagePath = $"{basePath}/{destination.Id}_fish.png";

            image.SaveAsPng(imagePath);

            return imagePath;
        }
    }
}
