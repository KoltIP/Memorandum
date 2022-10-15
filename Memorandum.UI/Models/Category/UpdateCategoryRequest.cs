using AutoMapper;
using FluentValidation;
using Memorandum.CategoryServices.Models;

namespace Memorandum.UI.Models.Category
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }

    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(50).WithMessage("Description is long.");
        }
    }

    public class UpdateCategoryRequestProfile : Profile
    {
        UpdateCategoryRequestProfile()
        {
            CreateMap<UpdateCategoryRequest, UpdateCategoryModel>();
        }
    }
}
