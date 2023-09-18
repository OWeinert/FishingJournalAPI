using AutoMapper;
using FishingJournal.API.Database;
using FishingJournal.API.Helpers;
using FishingJournal.API.Models;
using FishingJournal.API.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace FishingJournal.API.Controllers
{
    /// <summary>
    /// Base on: https://www.infragistics.com/community/blogs/b/infragistics/posts/create-role-based-web-api-with-asp-net-core
    /// </summary>
    /// <param name="username"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json", "application/xml")]
    [Produces("application/json", "application/xml")]
    public class AuthController : Controller
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly ILogger<AuthController> _logger;

        public AuthController(FishingJournalDbContext dbContext, UserManager<User> userManager, 
            SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration, 
            ILogger<AuthController> logger) 
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _jwtSettings = configuration.GetSection("Jwt");
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [RequireHttps]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterInputModel registerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userManager.FindByNameAsync(registerModel.UserName) != null)
                        return BadRequest("User already exists!");
                    if (_dbContext.Users.Count() >= _configuration.GetValue<int>("MaxUsers"))
                    {
                        _logger.LogWarning("A User tried to register, but the MaxUsers limit is reached!");
                        return BadRequest("API has reached maximum registered Users!");
                    }

                    var user = _mapper.Map<RegisterInputModel, User>(registerModel);

                    var result = await _userManager.CreateAsync(user, registerModel.Password);
                    if(!result.Succeeded)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, result.Errors);
                    }

                    var loginResult = await _signInManager.PasswordSignInAsync(user, registerModel.Password, false, lockoutOnFailure: false);
                    if (!loginResult.Succeeded)
                    {
                        return Unauthorized("Login failed");
                    }

                    var token = await GetJwt(user);
                    return Ok(token);
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
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [RequireHttps]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginInputModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);

                    if(user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);
                        if(!result.Succeeded)
                        {
                            return Unauthorized("Login failed");
                        }

                        var token = await GetJwt(user);
                        return Ok(token);
                    }

                    return Unauthorized("Username or Password are incorrect!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("User login failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [AllowAnonymous]
        [RequireHttps]
        [HttpPost(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Logout failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        

        private async Task<string> GetJwt(User user)
        {
            var signingCredentials = AuthHelper.GetSigningCredentials(_jwtSettings);
            var claims = AuthHelper.GetClaims(_userManager, user);
            var tokenOptions = AuthHelper.GenerateTokenOptions(_jwtSettings, signingCredentials, await claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
