using Memorandum.NoteServices.Services;
using Memorandum.UI.Models.Note;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Memorandum.UI.Controllers
{
    [Route("/note")]
    public class NoteContoller : Controller
    {
        private INoteService _noteService;

        [HttpGet("")]
        public Task<IEnumerable<NoteResponse>> GetNodes()
        {
            throw new Exception();
        }

        [HttpGet("{id}")]
        public Task<NoteResponse> GetNode([FromRoute] int id)
        {
            throw new Exception();
        }

        [HttpPost("")]
        public Task<NoteResponse> AddNode([FromBody] AddNoteRequest request)
        {
            throw new Exception();
        }

        [HttpPut("{id}")]
        public Task UpdateNode([FromRoute]int id,[FromBody] UpdateNoteRequest request)
        {
            throw new Exception();
        }

        [HttpDelete("{id}")]
        public Task DeleteNode([FromRoute]int id)
        {
            throw new Exception();
        }
    }
}
