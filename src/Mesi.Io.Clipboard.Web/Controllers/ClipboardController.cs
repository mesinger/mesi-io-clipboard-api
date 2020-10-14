using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Mesi.Io.Clipboard.Application.UseCases;
using Mesi.Io.Clipboard.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.Clipboard.Web.Controllers
{
    [ApiController]
    [Route("clipboard")]
    public class ClipboardController : Controller
    {
        private readonly ICreateNewClipboardEntry _createNewClipboardEntry;
        private readonly IFindAllClipboardEntriesByUser _findAllClipboardEntriesByUser;
        private readonly ILogger<ClipboardController> _logger;

        public ClipboardController(ICreateNewClipboardEntry createNewClipboardEntry, IFindAllClipboardEntriesByUser findAllClipboardEntriesByUser, ILogger<ClipboardController> logger)
        {
            _createNewClipboardEntry = createNewClipboardEntry;
            _findAllClipboardEntriesByUser = findAllClipboardEntriesByUser;
            _logger = logger;
        }

        [HttpPost]
        [Authorize("WriteClipboardScope")]
        public async Task<IActionResult> AddClipboardEntry([FromBody] AddClipboardEntryRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var result = await _createNewClipboardEntry.Create(new CreateNewClipboardEntryRequest(userId, request.Content));

            if (result.CreatedEntry.HasNoValue)
            {
                return BadRequest("Unable to create clipboard entry");
            }

            return Created("", new ClipboardEntryResponse(result.CreatedEntry.Value.Content.Content, result.CreatedEntry.Value.CreatedAt));
        }

        [HttpGet("getAll")]
        [Authorize("ReadClipboardScope")]
        public async Task<IActionResult> GetAllByUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (string.IsNullOrWhiteSpace(userId))
            {
                _logger.LogInformation("Unable to retrieve clipboard entries for user without valid user id");
                return BadRequest();
            }

            var result = await _findAllClipboardEntriesByUser.FindAll(new FindAllClipboardEntriesByUserRequest(userId));

            return Ok(from entry in result.Entries select new ClipboardEntryResponse(entry.Content.Content, entry.CreatedAt));
        }
    }
}