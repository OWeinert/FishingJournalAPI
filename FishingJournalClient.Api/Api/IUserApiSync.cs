using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserChangePasswordPut(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserChangePasswordPutWithHttpInfo(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserChangeUsernamePut(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserChangeUsernamePutWithHttpInfo(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserDeleteDelete(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0);
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
        ApiResponse<Object> UserDeleteDeleteWithHttpInfo(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserDeleteDirectDelete(string username = default(string), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserDeleteDirectDeleteWithHttpInfo(string username = default(string), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserGetAllGet(int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserGetAllGetWithHttpInfo(int operationIndex = 0);
        #endregion Synchronous Operations
    }
}
