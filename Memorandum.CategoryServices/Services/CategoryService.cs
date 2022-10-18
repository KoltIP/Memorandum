using AutoMapper;
using FluentValidation.Resources;
using Memorandum.CategoryServices.Models;
using Memorandum.Db.Context.Context;
using Memorandum.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.CategoryServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MemorandumDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(MemorandumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories(int offset = 0, int limit = 10)
        {
            var categories = _dbContext.Categories.AsQueryable();

            categories = categories
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var categoryList = await categories.ToListAsync();
            IEnumerable<CategoryModel> categoryModelList = categoryList.Select(category => _mapper.Map<CategoryModel>(category));

            return categoryModelList;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<CategoryModel> AddCategory(AddCategoryModel model)
        {
            var category = _mapper.Map<Category>(model);
            var entityEntry = await _dbContext.Categories.AddAsync(category);
            var categoryModel = _mapper.Map<CategoryModel>(entityEntry.Entity);            
            _dbContext.SaveChanges();

            return categoryModel;
        }

        public async Task UpdateCategory(int id, UpdateCategoryModel model)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));

            category = _mapper.Map(model, category);

            _dbContext.Categories.Update(category);

            _dbContext.SaveChanges();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
                _dbContext.Categories.Remove(category);

            _dbContext.SaveChanges();
        }
    }
}
