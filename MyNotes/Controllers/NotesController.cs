using Domain.Abstractions;
using Domain.DTOs.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromBody]CreateNoteRequest request, CancellationToken cancellationToken)
        {
            await _noteService.CreateNote(request.title, request.description, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetNoteRequest request, CancellationToken cancellationToken)
        {
            var notes = await _noteService.GetNotes(request.Search, request.SortItem, request.SortOrder, cancellationToken);
            return Ok(notes);
        }
    }
}
