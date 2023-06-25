using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.AspNetCore.Authorization;
using FishingJournal.API.Services;

namespace FishingJournal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [RequireHttps]
        [HttpGet("")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
              return _userService.UsersTableExists() ? 
                          View(await _userService.GetUsersAsync()) :
                          Problem("Entity set 'FishingJournalDbContext.Users'  is null.");
        }

        [RequireHttps]
        [HttpGet("details/{id?}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details([FromQuery]int? id)
        {
            if (id == null || !_userService.UsersTableExists())
            {
                return NotFound();
            }

            var user = await _userService.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost("create")]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody][Bind("Name,Password")]RawUser rawUser)
        {
            User? user = null;
            if (ModelState.IsValid)
            {
                user = await _userService.RegisterUserAsync(rawUser.Name, rawUser.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost("edit")]
        [RequireHttps]
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_userService.UsersTableExists())
            {
                return NotFound();
            }

            var user = await _userService.FirstAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost("edit/{id?}")]
        [RequireHttps]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromQuery]int id, [FromBody][Bind("Name,Password,Salt")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.EditUserAsync(id, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        [HttpPost("delete/{id?}")]
        [RequireHttps]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete([FromQuery]int? id)
        {
            if (id == null || !_userService.UsersTableExists())
            {
                return NotFound();
            }

            var user = await _userService.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [RequireHttps]
        [HttpPost("deleteSafe/{id}")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromQuery]int id)
        {
            if (!_userService.UsersTableExists())
            {
                return Problem("Entity set 'FishingJournalDbContext.Users'  is null.");
            }
            var user = await _userService.FindUserAsync(id);
            if (user != null)
            {
                await _userService.DeleteUserAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Exists")]
        [RequireHttps]
        private bool UserExists([FromQuery]int id)
        {
            return _userService.UserExists(u => u.Id == id);
        }
    }
}
