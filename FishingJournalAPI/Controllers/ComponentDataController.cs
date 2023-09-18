using AutoMapper;
using FishingJournal.API.Database;
using FishingJournal.API.Models.DTOs;
using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Controllers
{
    [Route("api/Data")]
    [ApiController]
    [Authorize]
    public class ComponentDataController : ControllerBase
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ComponentDataController> _logger;

        public ComponentDataController(FishingJournalDbContext dbContext, IMapper mapper,
            ILogger<ComponentDataController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ComponentContainer>> Get()
        {
            try
            {
                var container = new ComponentContainer
                {
                    FishTypes = await _dbContext.FishTypes.ToDTOListAsync<FishType, string, JournalEntry>(_mapper),
                    HookTypes = await _dbContext.HookTypes.ToDTOListAsync<HookType, string, JournalEntry>(_mapper),
                    HookSizes = await _dbContext.HookSizes.ToDTOListAsync<HookSize, string, JournalEntry>(_mapper),
                    RigTypes = await _dbContext.RigTypes.ToDTOListAsync<RigType, string, JournalEntry>(_mapper),
                    WeatherTypes = await _dbContext.WeatherTypes.ToDTOListAsync<WeatherType, string, JournalEntry>(_mapper),
                    WaterCurrentTypes = await _dbContext.WaterCurrentTypes.ToDTOListAsync<WaterCurrentType, string, JournalEntry>(_mapper),
                    WaterSurfaceTypes = await _dbContext.WaterSurfaceTypes.ToDTOListAsync<WaterSurfaceType, string, JournalEntry>(_mapper)
                };
                return Ok(container);
            }
            catch(Exception ex)
            {
                _logger.LogError("Fetching components failed! {ex}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
