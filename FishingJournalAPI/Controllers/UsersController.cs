using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.AspNetCore.Authorization;
using FishingJournal.API.Services;

namespace FishingJournal.API.Controllers
{
    [Route("user")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [RequireHttps]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
              return _userService.UsersTableExists() ? 
                          View(await _userService.GetUsersAsync()) :
                          Problem("Entity set 'FishingJournalDbContext.Users'  is null.");
        }

        [RequireHttps]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
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

        [RequireHttps]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string username, string password)
        {
            User? user = null;
            if (ModelState.IsValid)
            {
                user = await _userService.RegisterUserAsync(username, password);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
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

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [RequireHttps]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Password,Salt")] User user)
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

        // GET: Users/Delete/5
        [RequireHttps]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        [RequireHttps]
        private bool UserExists(int id)
        {
            return _userService.UserExists(u => u.Id == id);
        }
    }
}
