using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Exceptions;
using FishingJournal.Client.Api.Helpers;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class JournalEntryApi : IJournalEntryApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JournalEntryApi() : this((string)null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JournalEntryApi(string basePath)
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
        /// Initializes a new instance of the <see cref="JournalEntryApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public JournalEntryApi(Configuration configuration)
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
        /// Initializes a new instance of the <see cref="JournalEntryApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public JournalEntryApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
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
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryAddPost(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0)
        {
            JournalEntryAddPostWithHttpInfo(journalEntryDTO);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryAddPostWithHttpInfo(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0)
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
            localVarRequestOptions.Data = journalEntryDTO;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryAddPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/JournalEntry/Add", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryAddPost", localVarResponse);
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
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryAddPostAsync(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryAddPostWithHttpInfoAsync(journalEntryDTO, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryAddPostWithHttpInfoAsync(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = journalEntryDTO;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryAddPost";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/JournalEntry/Add", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryAddPost", localVarResponse);
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
        public void JournalEntryDeleteAllDelete(string username = default(string), int operationIndex = 0)
        {
            JournalEntryDeleteAllDeleteWithHttpInfo(username);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryDeleteAllDeleteWithHttpInfo(string username = default(string), int operationIndex = 0)
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
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryDeleteAllDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/JournalEntry/DeleteAll", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryDeleteAllDelete", localVarResponse);
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
        public async System.Threading.Tasks.Task JournalEntryDeleteAllDeleteAsync(string username = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryDeleteAllDeleteWithHttpInfoAsync(username, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryDeleteAllDeleteWithHttpInfoAsync(string username = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryDeleteAllDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/JournalEntry/DeleteAll", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryDeleteAllDelete", localVarResponse);
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
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryDeleteDelete(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0)
        {
            JournalEntryDeleteDeleteWithHttpInfo(entryModificationInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryDeleteDeleteWithHttpInfo(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0)
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
            localVarRequestOptions.Data = entryModificationInputModel;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryDeleteDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/JournalEntry/Delete", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryDeleteDelete", localVarResponse);
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
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryDeleteDeleteAsync(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryDeleteDeleteWithHttpInfoAsync(entryModificationInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryDeleteDeleteWithHttpInfoAsync(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = entryModificationInputModel;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryDeleteDelete";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/JournalEntry/Delete", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryDeleteDelete", localVarResponse);
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
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryEditPut(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0)
        {
            JournalEntryEditPutWithHttpInfo(entryModificationInputModel);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryEditPutWithHttpInfo(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0)
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
            localVarRequestOptions.Data = entryModificationInputModel;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryEditPut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/JournalEntry/Edit", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryEditPut", localVarResponse);
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
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryEditPutAsync(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryEditPutWithHttpInfoAsync(entryModificationInputModel, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryEditPutWithHttpInfoAsync(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = entryModificationInputModel;
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryEditPut";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/JournalEntry/Edit", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryEditPut", localVarResponse);
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
        public void JournalEntryGet(int operationIndex = 0)
        {
            JournalEntryGetWithHttpInfo();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryGetWithHttpInfo(int operationIndex = 0)
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
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/JournalEntry", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryGet", localVarResponse);
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
        public async System.Threading.Tasks.Task JournalEntryGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryGetWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/JournalEntry", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryGet", localVarResponse);
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
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryIdGet(int id, int operationIndex = 0)
        {
            JournalEntryIdGetWithHttpInfo(id);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryIdGetWithHttpInfo(int id, int operationIndex = 0)
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
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/JournalEntry/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryIdGet", localVarResponse);
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
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryIdGetAsync(int id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryIdGetWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryIdGetWithHttpInfoAsync(int id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/JournalEntry/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryIdGet", localVarResponse);
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
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryStartIndexEndIndexGet(int startIndex, int endIndex, int operationIndex = 0)
        {
            JournalEntryStartIndexEndIndexGetWithHttpInfo(startIndex, endIndex);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryStartIndexEndIndexGetWithHttpInfo(int startIndex, int endIndex, int operationIndex = 0)
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
            localVarRequestOptions.PathParameters.Add("startIndex", ClientUtils.ParameterToString(startIndex)); // path parameter
            localVarRequestOptions.PathParameters.Add("endIndex", ClientUtils.ParameterToString(endIndex)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryStartIndexEndIndexGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/JournalEntry/{startIndex}.{endIndex}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryStartIndexEndIndexGet", localVarResponse);
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
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryStartIndexEndIndexGetAsync(int startIndex, int endIndex, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryStartIndexEndIndexGetWithHttpInfoAsync(startIndex, endIndex, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryStartIndexEndIndexGetWithHttpInfoAsync(int startIndex, int endIndex, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("startIndex", ClientUtils.ParameterToString(startIndex)); // path parameter
            localVarRequestOptions.PathParameters.Add("endIndex", ClientUtils.ParameterToString(endIndex)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryStartIndexEndIndexGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/JournalEntry/{startIndex}.{endIndex}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryStartIndexEndIndexGet", localVarResponse);
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
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void JournalEntryUsernameGet(string username, int operationIndex = 0)
        {
            JournalEntryUsernameGetWithHttpInfo(username);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> JournalEntryUsernameGetWithHttpInfo(string username, int operationIndex = 0)
        {
            // verify the required parameter 'username' is set
            if (username == null)
            {
                throw new ApiException(400, "Missing required parameter 'username' when calling JournalEntryApi->JournalEntryUsernameGet");
            }
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
            localVarRequestOptions.PathParameters.Add("username", ClientUtils.ParameterToString(username)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryUsernameGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/JournalEntry/{username}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryUsernameGet", localVarResponse);
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
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task JournalEntryUsernameGetAsync(string username, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await JournalEntryUsernameGetWithHttpInfoAsync(username, operationIndex, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> JournalEntryUsernameGetWithHttpInfoAsync(string username, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'username' is set
            if (username == null)
            {
                throw new ApiException(400, "Missing required parameter 'username' when calling JournalEntryApi->JournalEntryUsernameGet");
            }
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
            localVarRequestOptions.PathParameters.Add("username", ClientUtils.ParameterToString(username)); // path parameter
            localVarRequestOptions.Operation = "JournalEntryApi.JournalEntryUsernameGet";
            localVarRequestOptions.OperationIndex = operationIndex;
            // authentication (Bearer) required
            // bearer authentication required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }
            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/JournalEntry/{username}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("JournalEntryUsernameGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }
            return localVarResponse;
        }
    }
}
