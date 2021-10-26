using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotionIntegration.Repositories;
using System;
using System.Threading.Tasks;

namespace NotionIntegration.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly INotesRepository _notesRepository;

        public TestController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
        }

        /// <summary>
        /// Checks if NotionIntegration is running.
        /// </summary>
        [HttpGet]
        [Route("health")]
        public IActionResult Index()
        {
            return Ok("NotionIntegration is alive.");
        }

        /// <summary>
        /// Adds a new note to the DB.
        /// </summary>
        /// <param name="text">Text field.</param>
        [HttpPost]
        [Route("addnote")]
        public async Task<IActionResult> AddNote(string text)
        {
            await _notesRepository.AddNoteAsync(text);
            return Ok("Note added.");
        }

        /// <summary>
        /// Returnes all notes from the DB.
        /// </summary>
        [HttpGet]
        [Route("notes")]
        public async Task<IActionResult> Notes()
        {
            var notes = await _notesRepository.GetNotesAsync();
            return Ok(JsonConvert.SerializeObject(notes, Formatting.Indented));
        }
    }
}
