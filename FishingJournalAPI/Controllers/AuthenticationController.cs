using AutoMapper;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FishingJournal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly FishingJournalDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService authService, FishingJournalDbContext dbContext,
            IMapper mapper, IConfiguration configuration, ILogger<AuthenticationController> logger) 
        {
            _authService = authService;
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [RequireHttps]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userModel.Password != userModel.ConfirmedPassword)
                        return BadRequest("Passwords do not match!");
                    if (await _authService.DoesUserExistAsync(userModel.Name))
                        return BadRequest("User already exists!");
                    if (_dbContext.Users.Count() >= _configuration.GetValue<int>("MaxUsers"))
                    {
                        _logger.LogWarning("A User tried to register, but the MaxUsers limit is reached!");
                        return BadRequest("API has reached maximum registered Users!");
                    }

                    var mappedModel = _mapper.Map<RegisterInputModel, User>(userModel);
                    mappedModel.Role = "User";

                    var user = await _authService.RegisterUserAsync(mappedModel);
                    if(user != null)
                    {
                        var token = _authService.GenerateJwtToken(user.Name, user.Role);
                        _logger.LogDebug("User {user} newly registered in and received token {token}", user.Name, token);
                        return Ok(token);
                    }
                    return BadRequest("Username and/or Password are incorrect!");
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                _logger.LogError("User registration failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [RequireHttps]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _authService.AuthenticateAsync(userModel.Name, userModel.Password))
                    {
                        var user = await _authService.GetByNameAsync(userModel.Name);
                        var token = _authService.GenerateJwtToken(user.Name, user.Role);
                        _logger.LogDebug("User {user} logged in and received token {token}", user.Name, token);
                        return Ok(token);
                    }
                    return BadRequest("Username or Password are incorrect!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("User login failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Authorize]
        [RequireHttps]
        [HttpPost(nameof(Logout))]
        public async Task<IActionResult> Logout(string token)
        {
            try
            {
                await _authService.LogoutAsync(token);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Logout failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
