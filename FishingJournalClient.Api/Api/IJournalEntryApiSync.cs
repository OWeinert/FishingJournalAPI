using FishingJournal.Client.Api.Config;
using FishingJournal.Client.Api.Model;

namespace FishingJournal.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJournalEntryApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryAddPost(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="journalEntryDTO"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryAddPostWithHttpInfo(JournalEntryDTO journalEntryDTO = default(JournalEntryDTO), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryDeleteAllDelete(string username = default(string), int operationIndex = 0);
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
        ApiResponse<Object> JournalEntryDeleteAllDeleteWithHttpInfo(string username = default(string), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryDeleteDelete(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryDeleteDeleteWithHttpInfo(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryEditPut(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="entryModificationInputModel"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryEditPutWithHttpInfo(EntryModificationInputModel entryModificationInputModel = default(EntryModificationInputModel), int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryGet(int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryGetWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryIdGet(int id, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryIdGetWithHttpInfo(int id, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryStartIndexEndIndexGet(int startIndex, int endIndex, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryStartIndexEndIndexGetWithHttpInfo(int startIndex, int endIndex, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void JournalEntryUsernameGet(string username, int operationIndex = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="username"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> JournalEntryUsernameGetWithHttpInfo(string username, int operationIndex = 0);
        #endregion Synchronous Operations
    }
}
