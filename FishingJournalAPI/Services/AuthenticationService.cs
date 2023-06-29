using FishingJournal.API.Database;
using FishingJournal.API.Helpers;
using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Base on: https://www.infragistics.com/community/blogs/b/infragistics/posts/create-role-based-web-api-with-asp-net-core
    /// </summary>
    /// <param name="username"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthenticationService(FishingJournalDbContext dbContext, IConfiguration configuration, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public string GenerateJwtToken(string username, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, username),
                        new Claim(JwtRegisteredClaimNames.Name, username),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:TokenLifetime")),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user = await GetByNameAsync(username);
            return await DoesUserExistAsync(username) && BC.EnhancedVerify(password, user.Password);
        }

        public async Task<bool> DoesUserExistAsync(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == username);
            return user != null;
        }

        public async Task<User> GetByIdAsync(string id) => await _dbContext.Users.FirstAsync(u => u.Id == id);

        public async Task<User> GetByNameAsync(string username) => await _dbContext.Users.FirstAsync(u => u.Name == username);

        public async Task<User> RegisterUserAsync(User userModel)
        {
            User? existsWithId;
            string? id;
            do
            {
                id = IdGenerator.CreateId(IdGenerator.DefaultLength);
                existsWithId = await GetByIdAsync(id);
            }
            while (existsWithId != null);

            userModel.Id = id;
            userModel.Password = BC.HashPassword(userModel.Password);
            var userEntity = await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();

            return userEntity.Entity;
        }

        public async Task ChangePasswordAsync(string username, string newPassword)
        {
            var user = await GetByNameAsync(username);
            user.Password = BC.EnhancedHashPassword(newPassword);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeUsernameAsync(string oldName, string newName)
        {
            var user = await GetByNameAsync(oldName);
            user.Name = newName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(string username)
        {
            var user = await GetByNameAsync(username);
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task LogoutAsync(string token) => await _tokenService.DeactiveAsync(token);
    }
}