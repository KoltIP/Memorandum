using Memorandum.UI.Configuration;

namespace Memorandum.UI.Configuration
{
    public static class MapperConfiguration
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            AutoMappersRegisterHelper.Register(services);

            return services;
        }
    }
}
