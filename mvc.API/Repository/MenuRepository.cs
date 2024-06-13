using mvc.Domains;

namespace mvc.Repository
{
    public interface IMenuReposity : IRepository<Menu>
    {
    }

    public class MenuRepository(AppDbContext context) : Repository<Menu>(context), IMenuReposity
    {
    }
}
