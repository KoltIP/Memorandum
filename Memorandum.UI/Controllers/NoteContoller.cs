using AutoMapper;
using Memorandum.NoteServices.Models;
using Memorandum.NoteServices.Services;
using Memorandum.UI.Models.Note;
using Microsoft.AspNetCore.Http;
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
        public async Task<IEnumerable<NoteResponse>> GetNotes()
        {
            var notes = await _noteService.GetNotes();
            var response = _mapper.Map<IEnumerable<NoteResponse>>(notes);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<NoteResponse> GetNote([FromRoute] int id)
        {
            var note = await _noteService.GetNote(id);
            var response = _mapper.Map<NoteResponse>(note);
            return response;
        }

        [HttpPost("")]
        public async Task<NoteResponse> AddNote([FromBody] AddNoteRequest request)
        {
            var model = _mapper.Map<AddNoteModel>(request);
            var note = await _noteService.AddNote(model);
            var response = _mapper.Map<NoteResponse>(note);
            return response;
        }


        [HttpPut("{id}")]
        public async Task<OkResult> UpdateNote([FromRoute] int id, [FromBody] UpdateNoteRequest request)
        {
            var model = _mapper.Map<UpdateNoteModel>(request);
            await _noteService.UpdateNote(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkResult> DeleteNote([FromRoute] int id)
        {
            await _noteService.DeleteNote(id);
            return Ok();
        }
    }
}
