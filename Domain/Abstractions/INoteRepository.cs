using Domain.DTOs.Contracts;
using Domain.Models;

namespace Domain.Abstractions;

public interface INoteRepository
{
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Add(Note note, CancellationToken cancellationToken);
    Task<GetNotesResponse> Get(string? search, string? sortItem, string? sortOrder, CancellationToken cancellationToken);
}