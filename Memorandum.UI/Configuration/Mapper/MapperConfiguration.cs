namespace Memorandum.UI.Configuration.Mapper
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
