namespace FishingJournal.API.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Checks if the current received token is active
        /// </summary>
        /// <returns></returns>
        Task<bool> IsCurrentActiveAsync();

        /// <summary>
        /// Deactivates the current received token
        /// </summary>
        /// <returns></returns>
        Task DeactiveCurrentAsync();

        /// <summary>
        /// Checks if the given <paramref name="token"/> is active
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> IsActiveAsync(string token);

        /// <summary>
        /// Deactivates the given <paramref name="token"/>
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task DeactiveAsync(string token);
    }
}
