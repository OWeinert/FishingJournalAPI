using AutoMapper;
using FishingJournal.API.Models;
using FishingJournal.API.Models.DTOs;
using FishingJournal.API.Models.InputModels;
using FishingJournal.API.Models.JournalEntryModels;
using FishingJournal.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FishingJournal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Entries")]
    [Consumes("application/json", "application/xml")]
    [Produces("application/json", "application/xml")]
    public class JournalEntryController : Controller
    {
        private readonly IJournalEntryService _journalEntryService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<JournalEntryController> _logger;

        public JournalEntryController(IJournalEntryService journalEntryService, UserManager<User> userManager,
            IMapper mapper, ILogger<JournalEntryController> logger)
        {
            _journalEntryService = journalEntryService;
            _userManager = userManager;
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
                var entries = await _journalEntryService.GetSliceAsync(startIndex, endIndex);
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
        [HttpGet("User/name:{username}")]
        public async Task<IActionResult> GetByName(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if(user != null)
                {
                    var dtos = GetUserJournalEntryDTOs(user);
                    return Ok(dtos);
                }
                return BadRequest("Invalid Username");
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
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("User/mail:{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var dtos = GetUserJournalEntryDTOs(user);
                    return Ok(dtos);
                }
                return BadRequest("Invalid Email");
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
        [RequireHttps]
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

                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (journalEntry.User != user)
                        return BadRequest("User is not permitted to edit this JournalEntry!");

                    var mappedJournalEntry = _mapper.Map<JournalEntry>(journalEntry);
                    await _journalEntryService.UpdateEntryAsync(journalEntry, mappedJournalEntry);
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
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var journalEntry = await _journalEntryService.FromIdAsync(model.JournalEntryId);

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
        public async Task<IActionResult> DeleteAll(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if(user != null)
                {
                    var entries = await _journalEntryService.GetUserEntriesAsync(user.Id);
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

        private List<JournalEntryDTO> GetUserJournalEntryDTOs(User user)
        {
            var entries = user.JournalEntries;
            var dtos = entries.ToList().ConvertAll(_mapper.Map<JournalEntry, JournalEntryDTO>);
            return dtos;
        }
    }
}
