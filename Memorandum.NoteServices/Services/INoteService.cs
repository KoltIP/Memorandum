using Memorandum.NoteServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.NoteServices.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteModel>> GetNotes(int offset = 0, int limit = 10);
        Task<NoteModel> GetNote(int id);
        Task<NoteModel> AddNote(AddNoteModel model);
        Task UpdateNote(int id, UpdateNoteModel model);
        Task DeleteNote(int id);
    }
}
