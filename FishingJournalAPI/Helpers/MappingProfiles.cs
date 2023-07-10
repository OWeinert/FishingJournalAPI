using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Helpers
{
    public class MappingProfile : Profile
    {

        public MappingProfile(IConfiguration configuration) 
        {
            CreateMap<RegisterInputModel, User>().ReverseMap();

            CreateMap<JournalEntryDTO, JournalEntry>()
                .ForMember(j => j.FishImagePath, opt => opt.MapFrom(new ImageBytesResolver(configuration), dto => dto.FishImage))
                .ForMember(j => j.CatchPlaceImagePath, opt => opt.MapFrom(new ImageBytesResolver(configuration), dto => dto.CatchPlaceImage));
            CreateMap<JournalEntry, JournalEntryDTO>()
                .ForMember(dto => dto.FishImage, opt => opt.MapFrom(new ImagePathResolver(), j => j.FishImagePath))
                .ForMember(dto => dto.CatchPlaceImage, opt => opt.MapFrom(new ImagePathResolver(), j => j.CatchPlaceImagePath));
        }
    }
}
