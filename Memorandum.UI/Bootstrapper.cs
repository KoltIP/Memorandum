using Memorandum.CategoryServices;
using Memorandum.NoteServices;

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
