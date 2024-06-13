using mvc.Domain;

namespace mvc.Infrastructure.Repositories
{
    public class MenuRepository(DbFactory dbFactory) : Repository<Menu>(dbFactory), IMenuRepository
    {
    }
}
