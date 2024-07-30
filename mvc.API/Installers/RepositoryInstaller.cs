using mvc.Domain;
using mvc.Domain.Interfaces;
using mvc.Infrastructure;
using mvc.Infrastructure.Repositories;

namespace mvc.API.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMenuRepository, MenuRepository>();
        }
    }
}
