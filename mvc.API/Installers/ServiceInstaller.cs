using mvc.API.Services;

namespace mvc.API.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenService, AuthenSerice>();
            services.AddScoped<IMenuService, MenuService>();
        }
    }
}
