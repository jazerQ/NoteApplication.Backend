using Domain.Models;
namespace Domain.Abstractions;
public interface INoteRepository
{
    Task Add(Note note);
    Task<List<Note>> Get();
}