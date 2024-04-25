using mvc.Domains;

namespace mvc.Services
{
    public interface IMenuService
    {
        List<AppController> GetMenu();
    }

    public class MenuService(AppDbContext context) : IMenuService
    {
        public List<AppController> GetMenu()
        {
            return [.. context.Controllers];
        }
    }
}
