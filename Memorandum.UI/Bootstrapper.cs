using Memorandum.CategoryServices;
using Memorandum.CategoryServices.Models;
using Memorandum.NoteServices;
using Memorandum.UI.Models.Category;
using Memorandum.UI.Models.Note;

namespace Memorandum.UI
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddCategoryService();
            services.AddNoteService();
            return services;
        }
    }
}
