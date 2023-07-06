using FishingJournal.API.Models;

namespace FishingJournal.API.Services
{
    /// <summary>
    /// Based on: https://www.infragistics.com/community/blogs/b/infragistics/posts/create-role-based-web-api-with-asp-net-core
    /// </summary>
    /// <param name="username"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the User with <paramref name="username"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True if the authentication was successful</returns>
        Task<bool> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Checks if a User with the given <paramref name="username"/> exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if the User exists</returns>
        Task<bool> DoesUserExistAsync(string username);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The User with the given <paramref name="id"/></returns>
        Task<User> GetByIdAsync(string id);

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByName(string username);

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <returns>The User with the given <paramref name="username"/></returns>
        Task<User> GetByNameAsync(string username);

        /// <summary>
        /// Registers a User with the given <paramref name="userModel"/>
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        Task<User> RegisterUserAsync(User userModel);

        /// <summary>
        /// Changes the password of the User with the given <paramref name="username"/> to the <paramref name="newPassword"/>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        Task ChangePasswordAsync(string username, string newPassword);

        /// <summary>
        /// Changes the Username of the given User from the <paramref name="oldName"/> to the <paramref name="newName"/>
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        Task ChangeUsernameAsync(string oldName, string newName);

        /// <summary>
        /// Removes the User with the given <paramref name="username"/> from the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task RemoveUserAsync(string username);

        /// <summary>
        /// Logs out a User by making their <paramref name="token"/> invalid
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task LogoutAsync(string token);
    }
}
