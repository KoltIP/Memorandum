namespace Memorandum.UI.Configuration
{
    public static class AutoMappersRegisterHelper
    {
        public static void Register(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("petproject."));

            services.AddAutoMapper(assemblies);
        }
    }
}
