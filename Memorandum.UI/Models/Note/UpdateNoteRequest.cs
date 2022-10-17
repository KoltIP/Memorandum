using AutoMapper;
using FluentValidation;
using Memorandum.NoteServices.Models;

namespace Memorandum.UI.Models.Note
{
    public class UpdateNoteRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Img { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }

    public class UpdateNoteRequestValidator : AbstractValidator<UpdateNoteRequest>
    {
        public UpdateNoteRequestValidator()
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

    public class UpdateNoteRequestProfile : Profile
    {
        public UpdateNoteRequestProfile()
        {
            CreateMap<UpdateNoteRequest, UpdateNoteModel>();
        }
    }

}
