using AutoMapper;
using Memorandum.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.NoteServices.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Img { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }
    public class NoteModelProfile : Profile
    {
        NoteModelProfile()
        {
            CreateMap<Note, NoteModel>();
        }
    }
}
