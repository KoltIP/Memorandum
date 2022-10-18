using AutoMapper;
using Memorandum.Db.Context.Context;
using Memorandum.Db.Entities;
using Memorandum.NoteServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.NoteServices.Services
{
    public class NoteService : INoteService
    {
        private readonly MemorandumDbContext _dbContext;
        private readonly IMapper _mapper;

        public NoteService(MemorandumDbContext dbContext, IMapper mapper)
        {
            
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteModel>> GetNotes(int offset = 0, int limit = 10)
        {
            var notes = _dbContext.Notes.AsQueryable();
            
            notes = notes.Include(x => x.Categoria);

            notes = notes                        
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));          

            var noteList = await notes.ToListAsync();
            IEnumerable<NoteModel> noteModelList = noteList.Select(note => _mapper.Map<NoteModel>(note));

            return noteModelList;
        }

        public async Task<NoteModel> GetNote(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<NoteModel>(note);
        }

        public async Task<NoteModel> AddNote(AddNoteModel model)
        {
            var note = _mapper.Map<Note>(model);
            var entityEntry = await _dbContext.Notes.AddAsync(note);
            var noteModel = _mapper.Map<NoteModel>(entityEntry.Entity);
            _dbContext.SaveChanges();

            return noteModel;
        }

        public async Task UpdateNote(int id, UpdateNoteModel model)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id.Equals(id));

            note = _mapper.Map(model, note);

            _dbContext.Notes.Update(note);

            _dbContext.SaveChanges();
        }

        public async Task DeleteNote(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

            if (note != null)
                _dbContext.Notes.Remove(note);

            _dbContext.SaveChanges();
        }
    }
}
