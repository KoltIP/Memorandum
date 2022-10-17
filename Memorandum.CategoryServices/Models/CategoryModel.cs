﻿using AutoMapper;
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
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CategoryModelProfile : Profile
    {
        public CategoryModelProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
