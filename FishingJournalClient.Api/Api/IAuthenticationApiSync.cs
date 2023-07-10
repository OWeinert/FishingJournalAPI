using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Exceptions;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthenticationApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void AuthenticationLoginPost(LoginInputModel loginInputModel = default, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<object> AuthenticationLoginPostWithHttpInfo(LoginInputModel loginInputModel = default, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void AuthenticationLogoutPost(string token = default, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<object> AuthenticationLogoutPostWithHttpInfo(string token = default, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void AuthenticationRegisterPost(RegisterInputModel registerInputModel = default, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<object> AuthenticationRegisterPostWithHttpInfo(RegisterInputModel registerInputModel = default, int operationIndex = 0);
        #endregion Synchronous Operations
    }
}
