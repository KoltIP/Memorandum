using AutoMapper;
using FluentValidation;
using Memorandum.CategoryServices.Models;

namespace Memorandum.UI.Models.Category
{
    public class AddCategoryRequest
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }

    public class AddCategoryRequestValidator: AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(50).WithMessage("Description is long.");
        }
    }

    public class AddCategoryRequestProfile : Profile
    {
        public AddCategoryRequestProfile()
        {
            CreateMap<AddCategoryRequest, AddCategoryModel>();
        }
    }

}
