using FishingJournal.API.Database;
using FishingJournal.API.Models.JournalEntryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComponentsController : ControllerBase
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly ILogger<ComponentsController> _logger;

        public ComponentsController(FishingJournalDbContext dbContext, ILogger<ComponentsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ComponentContainer>> Get()
        {
            try
            {
                var container = new ComponentContainer
                {
                    FishTypes = await _dbContext.FishTypes.ToListAsync(),
                    HookTypes = await _dbContext.HookTypes.ToListAsync(),
                    HookSizes = await _dbContext.HookSizes.ToListAsync(),
                    RigTypes = await _dbContext.RigTypes.ToListAsync(),
                    WeatherTypes = await _dbContext.WeatherTypes.ToListAsync(),
                    WaterCurrentTypes = await _dbContext.WaterCurrentTypes.ToListAsync(),
                    WaterSurfaceTypes = await _dbContext.WaterSurfaceTypes.ToListAsync()
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
