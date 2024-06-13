using mvc.Domain;
using mvc.Infrastructure;

namespace mvc.API.Repository
{
    public interface IMenuReposity : IRepository<Menu>
    {
    }

    public class MenuRepository(AppDbContext context) : Repository<Menu>(context), IMenuReposity
    {
    }
}
