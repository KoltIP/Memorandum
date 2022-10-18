using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.UI.Configuration
{
    public static class AutoMappersRegisterHelper
    {
        public static void Register(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("memorandum."));
            services.AddAutoMapper(assemblies);
            //services.AddAutoMappers(assemblies);
        }
    }
}
