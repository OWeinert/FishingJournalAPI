using FishingJournal.API.Database;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BC = BCrypt.Net.BCrypt;

namespace FishingJournal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json", "application/xml")]
    [Produces("application/json", "application/xml")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly FishingJournalDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuthenticationService authService, FishingJournalDbContext dbContext, ILogger<UserController> logger) 
        {
            _authService = authService;
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
                    if (!await _authService.DoesUserExistAsync(model.Name))
                        return BadRequest("User does not exist!");

                    var user = await _authService.GetByNameAsync(model.Name);
                    if (!BC.EnhancedVerify(model.OldPassword, user.Password))
                        return BadRequest("Old password is incorrect!");
                    if (model.NewPassword != model.ConfirmedNewPassword)
                        return BadRequest("New passwords do not match!");

                    await _authService.ChangePasswordAsync(model.Name, model.NewPassword);

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
                    if (!await _authService.DoesUserExistAsync(model.OldName))
                        return BadRequest("User does not exist!");

                    await _authService.ChangeUsernameAsync(model.OldName, model.NewName);

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
                        if (await _authService.AuthenticateAsync(userModel.Name, userModel.Password))
                        {
                            var user = await _authService.GetByNameAsync(userModel.Name);
                            _logger.LogDebug("User {user} deleted their account", user.Name);
                            return Ok();
                        }
                        return BadRequest("Username and/or Password are incorrect!");
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
        [Authorize(Roles = "Administrator")]
        [RequireHttps]
        [HttpDelete(nameof(DeleteDirect))]
        public async Task<IActionResult> DeleteDirect(string username)
        {
            try
            {
                if (await _authService.DoesUserExistAsync(username))
                {
                    await _authService.RemoveUserAsync(username);
                }
                return BadRequest($"Username {username} does not exist!");
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
        [RequireHttps]
        [HttpGet(nameof(GetAll))]
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
