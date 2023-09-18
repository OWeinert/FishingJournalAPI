using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Exceptions;
using FishingJournal.Client.Api.Helpers;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AuthenticationApi : IAuthenticationApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi() : this((string)null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi(string basePath)
        {
            Configuration = Config.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            Client = new ApiClient(Configuration.BasePath);
            AsynchronousClient = new ApiClient(Configuration.BasePath);
            ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AuthenticationApi(Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            Configuration = Config.Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            Client = new ApiClient(Configuration.BasePath);
            AsynchronousClient = new ApiClient(Configuration.BasePath);
            ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public AuthenticationApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");
            Client = client;
            AsynchronousClient = asyncClient;
            Configuration = configuration;
            ExceptionFactory = Config.Configuration.DefaultExceptionFactory;
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
            return Configuration.BasePath;
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void AuthenticationLoginPost(LoginInputModel loginInputModel = default, int operationIndex = 0)
        {
            AuthenticationLoginPostWithHttpInfo(loginInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> AuthenticationLoginPostWithHttpInfo(LoginInputModel loginInputModel = default, int operationIndex = 0)
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
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationLoginPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // make the HTTP request
            var localVarResponse = Client.Post<object>("/Authentication/Login", localVarRequestOptions, Configuration);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationLoginPost", localVarResponse);
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async Task AuthenticationLoginPostAsync(LoginInputModel loginInputModel = default, int operationIndex = 0, CancellationToken cancellationToken = default)
        {
            await AuthenticationLoginPostWithHttpInfoAsync(loginInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="loginInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async Task<ApiResponse<object>> AuthenticationLoginPostWithHttpInfoAsync(LoginInputModel loginInputModel = default, int operationIndex = 0, CancellationToken cancellationToken = default)
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
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationLoginPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // make the HTTP request
            var localVarResponse = await AsynchronousClient.PostAsync<object>("/Authentication/Login", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationLoginPost", localVarResponse);
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void AuthenticationLogoutPost(string token = default, int operationIndex = 0)
        {
            AuthenticationLogoutPostWithHttpInfo(token);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> AuthenticationLogoutPostWithHttpInfo(string token = default, int operationIndex = 0)
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
            if (token != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "token", token));
            }
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationLogoutPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = Client.Post<object>("/Authentication/Logout", localVarRequestOptions, Configuration);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationLogoutPost", localVarResponse);
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async Task AuthenticationLogoutPostAsync(string token = default, int operationIndex = 0, CancellationToken cancellationToken = default)
        {
            await AuthenticationLogoutPostWithHttpInfoAsync(token, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="token"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async Task<ApiResponse<object>> AuthenticationLogoutPostWithHttpInfoAsync(string token = default, int operationIndex = 0, CancellationToken cancellationToken = default)
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
            if (token != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "token", token));
            }
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationLogoutPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await AsynchronousClient.PostAsync<object>("/Authentication/Logout", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationLogoutPost", localVarResponse);
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void AuthenticationRegisterPost(RegisterInputModel registerInputModel = default, int operationIndex = 0)
        {
            AuthenticationRegisterPostWithHttpInfo(registerInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<object> AuthenticationRegisterPostWithHttpInfo(RegisterInputModel registerInputModel = default, int operationIndex = 0)
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
            localVarRequestOptions.Data = registerInputModel;
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationRegisterPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // make the HTTP request
            var localVarResponse = Client.Post<object>("/Authentication/Register", localVarRequestOptions, Configuration);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationRegisterPost", localVarResponse);
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
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async Task AuthenticationRegisterPostAsync(RegisterInputModel registerInputModel = default, int operationIndex = 0, CancellationToken cancellationToken = default)
        {
            await AuthenticationRegisterPostWithHttpInfoAsync(registerInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="registerInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async Task<ApiResponse<object>> AuthenticationRegisterPostWithHttpInfoAsync(RegisterInputModel registerInputModel = default, int operationIndex = 0, CancellationToken cancellationToken = default)
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
            localVarRequestOptions.Data = registerInputModel;
            localVarRequestOptions.Operation = "AuthenticationApi.AuthenticationRegisterPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // make the HTTP request
            var localVarResponse = await AsynchronousClient.PostAsync<object>("/Authentication/Register", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);
            if (ExceptionFactory != null)
            {
                var _exception = ExceptionFactory("AuthenticationRegisterPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
    }
}
