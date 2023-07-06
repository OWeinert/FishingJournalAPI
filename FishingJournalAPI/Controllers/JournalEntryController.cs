using AutoMapper;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Models.JournalEntryModels;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FishingJournal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json", "application/xml")]
    [Produces("application/json", "application/xml")]
    public class JournalEntryController : Controller
    {
        private readonly IJournalEntryService _journalEntryService;
        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger<JournalEntryController> _logger;

        public JournalEntryController(IJournalEntryService journalEntryService, IAuthenticationService authService,
            IMapper mapper, ILogger<JournalEntryController> logger)
        {
            _journalEntryService = journalEntryService;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entries = await _journalEntryService.GetAllAsync();
                var dtos = entries.ToList().ConvertAll(_mapper.Map<JournalEntry, JournalEntryDTO>);
                return Ok(dtos);
            }
            catch(Exception ex)
            {
                _logger.LogError("Retrieval of JournalEntries failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entry = await _journalEntryService.FirstOrDefaultAsync(j => j.Id == id);
                if(entry == null)
                {
                    return BadRequest($"JournalEntry with Id {id} does not exist!");
                }
                var dto = _mapper.Map<JournalEntry, JournalEntryDTO>(entry!);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval of JournalEntry failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [HttpGet("{startIndex}.{endIndex?}")]
        public async Task<IActionResult> Get(int startIndex, int? endIndex)
        {
            try
            {
                var entries = await _journalEntryService.GetSpanAsync(startIndex, endIndex);
                var dtos = entries.ToList().ConvertAll(_mapper.Map<JournalEntry, JournalEntryDTO>);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval of JournalEntries failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            try
            {
                var userId = (await _authService.GetByNameAsync(username)).Id;
                var entries = await _journalEntryService.GetUserEntriesAsync(userId);
                var dtos = entries.ToList().ConvertAll(_mapper.Map<JournalEntry, JournalEntryDTO>);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Retrieval of User's JournalEntries failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(JournalEntryDTO journalEntryDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var journalEntry = _mapper.Map<JournalEntryDTO, JournalEntry>(journalEntryDto);
                    await _journalEntryService.AddAsync(journalEntry);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Adding of JournalEntry failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut($"{nameof(Edit)}")]
        public async Task<IActionResult> Edit(EntryModificationInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NewJournalEntry == null)
                        return BadRequest("Sent JournalEntry can not be NULL!");

                    var journalEntry = await _journalEntryService.FromIdAsync(model.JournalEntryId);

                    var user = await _authService.GetByNameAsync(model.Username);
                    if (journalEntry.User != user)
                        return BadRequest("User is not permitted to edit this JournalEntry!");

                    await _journalEntryService.UpdateEntryAsync(journalEntry, model.NewJournalEntry);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Editing of JournalEntry failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [RequireHttps]
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(EntryModificationInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _authService.DoesUserExistAsync(model.Username))
                    {
                        var journalEntry = await _journalEntryService.FromIdAsync(model.JournalEntryId);

                        var user = await _authService.GetByNameAsync(model.Username);
                        if (journalEntry.User != user)
                            return BadRequest("User is not permitted to delete this JournalEntry!");

                        await _journalEntryService.RemoveAsync(journalEntry);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Deletion of JournalEntry failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [RequireHttps]
        [HttpDelete(nameof(DeleteAll))]
        public async Task<IActionResult> DeleteAll(string username)
        {
            try
            {
                if(await _authService.DoesUserExistAsync(username))
                {
                    var userId = (await _authService.GetByNameAsync(username)).Id;
                    var entries = await _journalEntryService.GetUserEntriesAsync(userId);
                    await _journalEntryService.RemoveMultipleAsync(entries);
                    return Ok();
                }
                return BadRequest("User does not exist!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Deletion of JournalEntries failed! {ex}", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
