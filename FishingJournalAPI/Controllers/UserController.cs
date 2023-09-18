using FishingJournal.API.Database;
using FishingJournal.API.Models;
using FishingJournal.API.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FishingJournal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json", "application/xml")]
    [Produces("application/json", "application/xml")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly FishingJournalDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<User> userManager, FishingJournalDbContext dbContext, 
            ILogger<UserController> logger) 
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [RequireHttps]
        [HttpPut(nameof(ChangePassword))]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user == null)
                        return BadRequest("User does not exist!");

                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if(!result.Succeeded)
                    {
                        return Unauthorized("Invalid Credentials");
                    }
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Password change failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [RequireHttps]
        [HttpPut(nameof(ChangeUsername))]
        public async Task<IActionResult> ChangeUsername(ChangeNameInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user == null)
                        return BadRequest("User does not exist!");

                    var result = await _userManager.SetUserNameAsync(user, model.NewName);

                    if(!result.Succeeded)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors);
                    }
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Username change failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [RequireHttps]
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(LoginInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ModelState.IsValid)
                    {
                        var user = await _userManager.FindByEmailAsync(userModel.Email);
                        if (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
                        {
                            var result = await _userManager.DeleteAsync(user);

                            if(!result.Succeeded)
                            {
                                return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors);
                            }

                            _logger.LogDebug("User {user} deleted their account", user.UserName);
                            return Ok();
                        }
                        return BadRequest("Invalid Credentials");
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("User deletion failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [RequireHttps]
        [HttpDelete(nameof(DeleteDirect))]
        public async Task<IActionResult> DeleteDirect(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if(!result.Succeeded)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors);
                    }
                }
                return BadRequest($"User with Email \"{email}\" does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError("User deletion failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [RequireHttps]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval of user list failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
