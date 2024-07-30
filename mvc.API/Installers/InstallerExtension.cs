namespace mvc.API.Installers
{
    public static class InstallerExtension
    {
        public static void InstallerServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installer = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installer.ForEach(x => x.InstallService(services, configuration));
        }
    }
}
