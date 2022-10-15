using AutoMapper;
using FluentValidation;
using Memorandum.CategoryServices.Models;
using Memorandum.NoteServices.Models;
using Memorandum.UI.Models.Category;

namespace Memorandum.UI.Models.Note
{
    public class AddNoteRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Img { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }
    public class AddNoteRequestValidator : AbstractValidator<AddNoteRequest>
    {
        public AddNoteRequestValidator()
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

    public class AddNoteRequestProfile : Profile
    {
        AddNoteRequestProfile()
        {
            CreateMap<AddNoteRequest, AddNoteModel>();
        }
    }
}
