using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Exceptions;
using FishingJournal.Client.Api.Helpers;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UserApi : IUserApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserApi() : this((string)null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserApi(string basePath)
        {
            this.Configuration = Config.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            this.Client = new ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UserApi(Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            this.Configuration = Config.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public UserApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");
            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public IAsynchronousClient AsynchronousClient { get; set; }
        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ISynchronousClient Client { get; set; }
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IReadableConfiguration Configuration { get; set; }
        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserChangePasswordPut(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0)
        {
            UserChangePasswordPutWithHttpInfo(changePasswordInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UserChangePasswordPutWithHttpInfo(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0)
        {
            var localVarRequestOptions = new Config.RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = changePasswordInputModel;
            localVarRequestOptions.Operation = "UserApi.UserChangePasswordPut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/User/ChangePassword", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserChangePasswordPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserChangePasswordPutAsync(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserChangePasswordPutWithHttpInfoAsync(changePasswordInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changePasswordInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UserChangePasswordPutWithHttpInfoAsync(ChangePasswordInputModel changePasswordInputModel = default(ChangePasswordInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = changePasswordInputModel;
            localVarRequestOptions.Operation = "UserApi.UserChangePasswordPut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/User/ChangePassword", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserChangePasswordPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserChangeUsernamePut(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0)
        {
            UserChangeUsernamePutWithHttpInfo(changeNameInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UserChangeUsernamePutWithHttpInfo(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0)
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = changeNameInputModel;
            localVarRequestOptions.Operation = "UserApi.UserChangeUsernamePut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/User/ChangeUsername", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserChangeUsernamePut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserChangeUsernamePutAsync(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserChangeUsernamePutWithHttpInfoAsync(changeNameInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="changeNameInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UserChangeUsernamePutWithHttpInfoAsync(ChangeNameInputModel changeNameInputModel = default(ChangeNameInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = changeNameInputModel;
            localVarRequestOptions.Operation = "UserApi.UserChangeUsernamePut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/User/ChangeUsername", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserChangeUsernamePut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserDeleteDelete(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0)
        {
            UserDeleteDeleteWithHttpInfo(loginInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UserDeleteDeleteWithHttpInfo(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0)
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = loginInputModel;
            localVarRequestOptions.Operation = "UserApi.UserDeleteDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/User/Delete", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserDeleteDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserDeleteDeleteAsync(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserDeleteDeleteWithHttpInfoAsync(loginInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UserDeleteDeleteWithHttpInfoAsync(LoginInputModel loginInputModel = default(LoginInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
                "application/json",
                "application/xml"
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Data = loginInputModel;
            localVarRequestOptions.Operation = "UserApi.UserDeleteDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/User/Delete", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserDeleteDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserDeleteDirectDelete(string username = default(string), int operationIndex = 0)
        {
            UserDeleteDirectDeleteWithHttpInfo(username);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UserDeleteDirectDeleteWithHttpInfo(string username = default(string), int operationIndex = 0)
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            if (username != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "username", username));
            }
            localVarRequestOptions.Operation = "UserApi.UserDeleteDirectDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/User/DeleteDirect", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserDeleteDirectDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserDeleteDirectDeleteAsync(string username = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserDeleteDirectDeleteWithHttpInfoAsync(username, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UserDeleteDirectDeleteWithHttpInfoAsync(string username = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            if (username != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "username", username));
            }
            localVarRequestOptions.Operation = "UserApi.UserDeleteDirectDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/User/DeleteDirect", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserDeleteDirectDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserGetAllGet(int operationIndex = 0)
        {
            UserGetAllGetWithHttpInfo();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> UserGetAllGetWithHttpInfo(int operationIndex = 0)
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Operation = "UserApi.UserGetAllGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/User/GetAll", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserGetAllGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserGetAllGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserGetAllGetWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> UserGetAllGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var localVarRequestOptions = new RequestOptions();
            var _contentTypes = new string[] {
            };
            // to determine the Accept header
            var _accepts = new string[] {
            };
            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }
            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }
            localVarRequestOptions.Operation = "UserApi.UserGetAllGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/User/GetAll", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserGetAllGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
    }
}
