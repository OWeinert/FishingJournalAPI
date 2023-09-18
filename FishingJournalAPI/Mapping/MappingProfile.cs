using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.DTOs;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.AspNetCore.Identity;

namespace FishingJournal.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IConfiguration configuration) 
        {
            CreateMap<RegisterInputModel, User>().ReverseMap();

            CreateMap<JournalEntryDTO, JournalEntry>()
                .ForMember(j => j.FishImagePath, opt => opt.MapFrom(new ImageBytesResolver(configuration), dto => dto.FishImage))
                .ForMember(j => j.CatchPlaceImagePath, opt => opt.MapFrom(new ImageBytesResolver(configuration), dto => dto.CatchPlaceImage))
                .ForMember(j => j.FishType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, FishType>()))
                .ForMember(j => j.RigType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, RigType>()))
                .ForMember(j => j.HookType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, HookType>()))
                .ForMember(j => j.HookSize, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, HookSize>()))
                .ForMember(j => j.WeatherType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, WeatherType>()))
                .ForMember(j => j.WaterSurfaceType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, WaterSurfaceType>()))
                .ForMember(j => j.WaterCurrentType, opt => opt.ConvertUsing(new ValueToDbEntryConverter<string, WaterCurrentType>()));
            CreateMap<JournalEntry, JournalEntryDTO>()
                .ForMember(dto => dto.FishImage, opt => opt.MapFrom(new ImagePathResolver(), j => j.FishImagePath))
                .ForMember(dto => dto.CatchPlaceImage, opt => opt.MapFrom(new ImagePathResolver(), j => j.CatchPlaceImagePath))
                .ForMember(dto => dto.FishType, opt => opt.MapFrom(src => src.FishType!.Value))
                .ForMember(dto => dto.RigType, opt => opt.MapFrom(src => src.RigType!.Value))
                .ForMember(dto => dto.HookType, opt => opt.MapFrom(src => src.HookType!.Value))
                .ForMember(dto => dto.HookSize, opt => opt.MapFrom(src => src.HookSize!.Value))
                .ForMember(dto => dto.WeatherType, opt => opt.MapFrom(src => src.WeatherType!.Value))
                .ForMember(dto => dto.WaterSurfaceType, opt => opt.MapFrom(src => src.WaterSurfaceType!.Value))
                .ForMember(dto => dto.WaterCurrentType, opt => opt.MapFrom(src => src.WaterCurrentType!.Value));

            CreateMap<FishType, ComponentDTO<string>>().ReverseMap();
            CreateMap<RigType, ComponentDTO<string>>().ReverseMap();
            CreateMap<HookType, ComponentDTO<string>>().ReverseMap();
            CreateMap<HookSize, ComponentDTO<string>>().ReverseMap();
            CreateMap<WeatherType, ComponentDTO<string>>().ReverseMap();
            CreateMap<WaterSurfaceType, ComponentDTO<string>>().ReverseMap();
            CreateMap<WaterCurrentType, ComponentDTO<string>>().ReverseMap();
        }
    }
}
