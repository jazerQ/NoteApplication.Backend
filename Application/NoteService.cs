using Domain.Models;
using Domain.Abstractions;
using Domain.DTOs.Contracts;

namespace Application;
public class NoteService : INoteService
{
    private readonly INoteRepository _repository;
    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateNote(string title, string descriptions, CancellationToken cancellationToken)
    {
        var note = new Note(title, descriptions);
        await _repository.Add(note, cancellationToken);
    }

    public async Task<GetNotesResponse> GetNotes(string? search, string? sortItem, string? sortOrder, CancellationToken cancellationToken)
    {
        return await _repository.Get(search, sortItem, sortOrder, cancellationToken);
    }
}
