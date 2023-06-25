using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace FishingJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntriesController : Controller
    {
        private readonly FishingJournalDbContext _context;
        private readonly IConfiguration _configuration;

        public JournalEntriesController(FishingJournalDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if(_context.JournalEntries == null)
                Problem("Entity set 'FishingJournalDbContext.JournalEntries'  is null.");
            var entries = await _context.JournalEntries!.ToListAsync();
            entries.ForEach(async j => await j.ConvertPathsToImagesAsync());
            return View(entries);
        }

        [HttpGet("details/{id?}")]
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JournalEntries == null)
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
                await journalEntry.ConvertImagesToPathsAsync(_configuration.GetValue<string>("ImagesPath"));
                _context.Add(journalEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(journalEntry);
        }

        [HttpPost("edit")]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JournalEntries == null)
            {
                return NotFound();
            }

            var journalEntry = await _context.JournalEntries.FindAsync(id);
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
                    _context.Update(journalEntry);
                    await _context.SaveChangesAsync();
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
            if (id == null || _context.JournalEntries == null)
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

        [HttpPost("deleteSafe/{id}")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JournalEntries == null)
            {
                return Problem("Entity set 'FishingJournalDbContext.JournalEntries'  is null.");
            }
            var journalEntry = await _context.JournalEntries.FindAsync(id);
            if (journalEntry != null)
            {
                _context.JournalEntries.Remove(journalEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Exists")]
        private bool JournalEntryExists(int id)
        {
          return (_context.JournalEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
