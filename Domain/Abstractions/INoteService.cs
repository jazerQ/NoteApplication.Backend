using Domain.DTOs.Contracts;
using Domain.Models;

namespace Domain.Abstractions;
public interface INoteService
{
    Task CreateNote(string title, string descriptions, CancellationToken cancellationToken);
    Task<GetNotesResponse> GetNotes(string? search, string? sortItem, string? sortOrder, CancellationToken cancellationToken);
    Task DeleteNote(Guid id, CancellationToken cancellation);
}
