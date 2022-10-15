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
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }

    public class CategoryModelProfile : Profile
    {
        CategoryModelProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
