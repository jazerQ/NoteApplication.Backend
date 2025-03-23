using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions;
using Domain.DTOs.Contracts;
using System.Linq.Expressions;

namespace DataAccess.Repositories;
public class NoteRepository : INoteRepository
{
    private readonly NoteDbContext _context;
    public NoteRepository(NoteDbContext context)
    {
        _context = context;
    }
    public async Task Add(Note note, CancellationToken cancellationToken)
    {
        await _context.Note.AddAsync(note, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<GetNotesResponse> Get(string? search, string? sortItem, string? sortOrder, CancellationToken cancellationToken)
    {
        var notesQuery = _context.Note.Where(n => !string.IsNullOrEmpty(search) &&
            n.Title.ToLower().Contains(search.ToLower())
        );

        if (!string.IsNullOrEmpty(sortOrder) && !string.IsNullOrEmpty(sortItem))
        {

            var selectorKey = GetSelectorKey(sortItem);
            notesQuery = sortOrder == "desc" ? 
                notesQuery.OrderByDescending(selectorKey)
                : notesQuery.OrderBy(selectorKey);
        }

        var notes = await notesQuery.Select(n => new NoteDto(n.Id, n.Title, n.Description, n.CreatedAt))
            .ToListAsync(cancellationToken);

        return new GetNotesResponse(notes);
    }

    private Expression<Func<Note, object>> GetSelectorKey(string sortItem) 
    {
        switch (sortItem) 
        {
            case "Title":
                //Expression<Func<Note, object>> selectorKey = note => note.Title;
                return note => note.Title;

            case "Description":
                return note => note.Description;

            case "CreatedAt":
                return note => note.CreatedAt;

            default:
                throw new Exception("Wrong Selector Key!");
        }
    }
}
