using FishingJournal.API.Authentication;
using FishingJournal.API.Database;
using FishingJournal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Implementation of IUserService
    /// </summary>
    public class UserService : IUserService
    {
        private readonly int _maxUsers;
        public int MaxUsers => _maxUsers;

        private readonly FishingJournalDbContext _dbContext;
        private readonly ILogger<UserService> _logger;

        public UserService(FishingJournalDbContext dbContext, ILogger<UserService> logger, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _logger = logger;
            _maxUsers = configuration.GetValue<int>("MaxUsers");
        }

        public async Task DeleteUserAsync(string username)
        {
            var user = await FindUserAsync(username);
            await DeleteUserAsync(user!);
        }

        public async Task DeleteUserAsync(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("User registration failed! {ex}", ex);
            }
        }

        public async Task<User> RegisterUserAsync(string username, string password)
        {
            try
            {
                if ((await _dbContext.Users.CountAsync()) > MaxUsers)
                    throw new Exception("Maximum amount of registered Users reached!");

                var hash = Hashing.HashPassword(password, out var salt);
                var user = new User
                {   
                    Name = username,
                    Password = password,
                    Salt = salt
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("User registration failed! {ex}", ex);
            }
            throw new Exception("Failed to create user");
        }

        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new ArgumentNullException(nameof(username), "Username is NULL or empty");
                if(string.IsNullOrEmpty(password))
                    throw new ArgumentNullException(nameof(password), "Password is NULL or empty");

                var user = await FindUserAsync(username);
                return Hashing.VerifyPassword(password, user!.Password, user.Salt);
            }
            catch (Exception ex)
            {
                _logger.LogError("User credential validation failed! {ex}", ex);
            }
            return false;
        }

        public async Task ChangeUserPasswordAsync(string username, string newPassword)
        {
            var user = await FindUserAsync(username);
            await ChangeUserPasswordAsync(user!, newPassword);
        }

        public async Task ChangeUserPasswordAsync(User user, string newPassword)
        {
            try
            {
                var hash = Hashing.HashPassword(newPassword, out var salt);
                user.Password = hash;
                user.Salt = salt;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Password change failed! {ex}", ex);
            }
        }

        public async Task<User?> FindUserAsync(string username)
        {
            try
            {
                return await _dbContext.Users.FindAsync(username);
            }
            catch(Exception ex)
            {
                _logger.LogError("Can't find user with name {name}! {ex}", username, ex);
            }
            return null;
        }

        public async Task<User?> FindUserAsync(int id)
        {
            try
            {
                return await _dbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't find user with ID {id}! {ex}", id, ex);
            }
            return null;
        }

        public async Task<User> FirstAsync(Func<User, bool> predicate) => await _dbContext.Users.FirstAsync(u => predicate(u));

        public async Task<User?> FirstOrDefaultAsync(Func<User, bool> predicate) => await _dbContext.Users.FirstOrDefaultAsync(u => predicate(u));

        public async Task EditUserAsync(int id, User user)
        {
            if (id != user.Id)
                throw new ArgumentException("given ID does not match user ID", nameof(id));
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsersAsync() => await _dbContext.Users.ToListAsync();

        public async Task<bool> UserExistsAsync(Func<User, bool> predicate) => await _dbContext.Users.AnyAsync(u => predicate(u));

        public bool UserExists(Func<User, bool> predicate) => _dbContext.Users.Any(u => predicate(u));

        public bool UsersTableExists() => _dbContext.Users != null;
    }
}
