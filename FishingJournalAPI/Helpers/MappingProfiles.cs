using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Models.JournalEntryModels;

namespace FishingJournal.API.Helpers
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<RegisterInputModel, User>().ReverseMap();
        }
    }
}
