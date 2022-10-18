using AutoMapper;
using Memorandum.NoteServices.Models;
using Memorandum.NoteServices.Services;
using Memorandum.UI.Models.Note;
using Microsoft.AspNetCore.Mvc;

namespace Memorandum.UI.Controllers
{
    [Route("/note")]
    public class NoteContoller : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;
        private readonly ILogger<NoteContoller> _logger;

        public NoteContoller(INoteService noteService, IMapper mapper, ILogger<NoteContoller> logger)
        {
            _noteService = noteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var notes = await _noteService.GetNotes();
            var response = _mapper.Map<IEnumerable<NoteResponse>>(notes);
            return View("Note", response);
        }

        [HttpGet("{id}")]
        public async Task<NoteResponse> GetNote([FromRoute] int id)
        {
            var note = await _noteService.GetNote(id);
            var response = _mapper.Map<NoteResponse>(note);
            return response;
        }

        [HttpGet("/OpenNoteAddPage")]
        public IActionResult OpenAddNotePage()
        {
            return View("AddNote");
        }

        [HttpPost("AddNote")]
        public async Task<IActionResult> Add(AddNoteRequest request)
        {
            var model = _mapper.Map<AddNoteModel>(request);
            var note = await _noteService.AddNote(model);
            var response = _mapper.Map<NoteResponse>(note);
            return Redirect("/note");
        }

        [HttpGet("/OpenNoteUpdatePage")]
        public async Task<IActionResult> OpenUpdateNotePageAsync(int id)
        {
            var note = await _noteService.GetNote(id);
            var response = _mapper.Map<NoteResponse>(note);
            return View("UpdateNote", response);
        }

        [HttpPost("UpdateNote")]
        public async Task<IActionResult> Update(int id, UpdateNoteRequest request)
        {
            UpdateNoteModel model = _mapper.Map<UpdateNoteModel>(request);
            await _noteService.UpdateNote(id, model);
            return Redirect("/note");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            await _noteService.DeleteNote(id);
            var notes = await _noteService.GetNotes();
            var response = _mapper.Map<IEnumerable<NoteResponse>>(notes);
            return View("Note", response);
        }
    }
}
