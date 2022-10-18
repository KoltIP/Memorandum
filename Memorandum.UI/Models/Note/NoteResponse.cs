using AutoMapper;
using FluentValidation;
using Memorandum.NoteServices.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Memorandum.UI.Models.Note
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Img { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }

    public class NoteResponseValidator : AbstractValidator<NoteResponse>
    {
        public NoteResponseValidator()
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

    public class NoteResponseProfile : Profile
    {
        public NoteResponseProfile()
        {
            CreateMap<NoteModel, NoteResponse>();
        }
    }
}
