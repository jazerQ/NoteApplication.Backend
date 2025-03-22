using Domain.Models;

namespace Domain.Abstractions;
public interface INoteService
{
    Task CreateNote(string title, string descriptions);
    Task<List<Note>> GetNotes();
}
