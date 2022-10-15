using AutoMapper;
using FluentValidation;
using Memorandum.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.NoteServices.Models
{
    public class UpdateNoteModel
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Img { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }

    public class UpdateNoteModelValidator : AbstractValidator<UpdateNoteModel>
    {
        public UpdateNoteModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(50).WithMessage("Description is long.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }
    }

    public class UpdateNoteModelProfile : Profile
    {
        UpdateNoteModelProfile()
        {
            CreateMap<UpdateNoteModel, Note>();
        }
    }
}
