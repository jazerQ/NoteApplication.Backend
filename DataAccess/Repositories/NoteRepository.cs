using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Abstractions;

namespace DataAccess.Repositories;
public class NoteRepository : INoteRepository
{
    private readonly NoteDbContext _context;
    public NoteRepository(NoteDbContext context)
    {
        _context = context;
    }
    public async Task Add(Note note)
    {
        await _context.Note.AddAsync(note);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Note>> Get()
    {
        return await _context.Note.ToListAsync();
    }
}
