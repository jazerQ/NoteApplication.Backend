using DataAccess.Repositories;
using Domain.Models;
using Domain.Abstractions;

namespace Application;
public class NoteService : INoteService
{
    private readonly INoteRepository _repository;
    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateNote(string title, string descriptions)
    {
        var note = new Note(title, descriptions);
        await _repository.Add(note);
    }

    public async Task<List<Note>> GetNotes()
    {
        return await _repository.Get();
    }
}
