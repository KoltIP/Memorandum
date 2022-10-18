using Memorandum.CategoryServices.Models;
using Memorandum.CategoryServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.CategoryServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCategoryService(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(AddCategoryModelProfile));
            services.AddAutoMapper(typeof(CategoryModelProfile));
            services.AddAutoMapper(typeof(UpdateCategoryModelProfile));
            
            return services;
        }
    }
}
