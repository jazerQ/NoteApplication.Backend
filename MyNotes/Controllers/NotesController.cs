using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Contracts;

namespace MyNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService) 
        {
            _noteService = noteService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateNoteRequest request)
        {
            await _noteService.CreateNote(request.title, request.description);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notes = await _noteService.GetNotes();
            return Ok(notes);
        }
    }
}
