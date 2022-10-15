using AutoMapper;
using FluentValidation;
using Memorandum.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.CategoryServices.Models
{
    public class UpdateCategoryModel
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }

    public class UpdateCategoryModelValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(50).WithMessage("Description is long.");
        }
    }

    public class UpdateCategoryModelProfile : Profile
    {
        UpdateCategoryModelProfile()
        {
            CreateMap<UpdateCategoryModel, Category>();
        }
    }
}
