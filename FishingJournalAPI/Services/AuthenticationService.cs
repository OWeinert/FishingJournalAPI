using FishingJournal.API.Database;
using FishingJournal.API.Helpers;
using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Implementation of <see cref="IAuthenticationService"/>
    /// 
    /// Based on: https://www.infragistics.com/community/blogs/b/infragistics/posts/create-role-based-web-api-with-asp-net-core
    /// </summary>
    /// <param name="username"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly FishingJournalDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthenticationService(FishingJournalDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
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

        public User GetByName(string username) => _dbContext.Users.First(u => u.Name == username);

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