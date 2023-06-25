using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.AspNetCore.Authorization;
using FishingJournal.API.Services;

namespace FishingJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntriesController : Controller
    {
        private readonly IJournalEntryService _journalEntryService;
        private readonly IConfiguration _configuration;

        public JournalEntriesController(IJournalEntryService journalEntryService, IConfiguration configuration)
        {
            _journalEntryService = journalEntryService;
            _configuration = configuration;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if(!_journalEntryService.IsTableExistent())
                Problem("Entity set 'FishingJournalDbContext.JournalEntries'  is null.");
            var entries = await _journalEntryService.GetEntriesForTransferAsync();
            return View(entries);
        }

        [HttpGet("details/{id?}")]
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_journalEntryService.IsTableExistent())
            {
                return NotFound();
            }

            var journalEntry = await _context.JournalEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        [HttpPost("create")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,FishType,Length,Weight,FishNickname,RigType,HookType,BaitInfo,FeedInfo,FeedDuration,LocationName,WeatherType,WindStrength,WindDirection,WaterSurfaceType,WaterCurrentType,AirPressure,AirPressureTendency,AirTemperature,WaterTemperature,AdditionalInfo,FishImagePath,CatchPlaceImagePath")] JournalEntry journalEntry)
        {
            if (ModelState.IsValid)
            {
                await _journalEntryService.AddAsync(journalEntry);
                return RedirectToAction(nameof(Index));
            }
            return View(journalEntry);
        }

        [HttpPost("edit")]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_journalEntryService.IsTableExistent())
            {
                return NotFound();
            }

            var journalEntry = await _journalEntryService.FromIdAsync(id);
            if (journalEntry == null)
            {
                return NotFound();
            }
            return View(journalEntry);
        }

        [HttpPost("edit/{id?}")]
        [RequireHttps]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,FishType,Length,Weight,FishNickname,RigType,HookType,BaitInfo,FeedInfo,FeedDuration,LocationName,WeatherType,WindStrength,WindDirection,WaterSurfaceType,WaterCurrentType,AirPressure,AirPressureTendency,AirTemperature,WaterTemperature,AdditionalInfo,FishImagePath,CatchPlaceImagePath")] JournalEntry journalEntry)
        {
            if (id != journalEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _journalEntryService.UpdateEntryAsync(journalEntry);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalEntryExists(journalEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(journalEntry);
        }

        [HttpPost("delete/{id?}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_journalEntryService.IsTableExistent())
            {
                return NotFound();
            }

            var journalEntry = await _journalEntryService.FirstOrDefaultAsync(m => m.Id == id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        [HttpPost("deleteSafe/{id}")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_journalEntryService.IsTableExistent())
            {
                return Problem("Entity set 'FishingJournalDbContext.JournalEntries'  is null.");
            }
            var journalEntry = await _journalEntryService.FromIdAsync(id);
            if (journalEntry != null)
            {
                await _journalEntryService.RemoveAsync(journalEntry);
            }
            
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Exists")]
        private bool JournalEntryExists(int id)
        {
          return _journalEntryService.EntryExistsAsync(id).Result;
        }
    }
}
