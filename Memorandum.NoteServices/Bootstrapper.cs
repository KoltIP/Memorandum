using Memorandum.NoteServices.Models;
using Memorandum.NoteServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.NoteServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddNoteService(this IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            return services;
        }
    }
}
