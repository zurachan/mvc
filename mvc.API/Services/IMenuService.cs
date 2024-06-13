using mvc.Domains;
using mvc.Repository;

namespace mvc.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenu();
        Menu SaveMenu(Menu model);
    }

    public class MenuService(AppDbContext context) : IMenuService
    {
        public List<Menu> GetMenu()
        {
            //var listMenu = unitOfWork.MenuRepository.Get();


            return [.. context.Menu];
        }

        public Menu SaveMenu(Menu model)
        {
            if (model.Id == 0) context.Menu.Add(model);
            else
            {
                var domain = context.Menu.FirstOrDefault(x => x.Id == model.Id);
                if (domain != null)
                {
                    domain.Name = model.Name;
                    domain.Path = model.Path;
                    domain.ParentId = model.ParentId;

                    context.Menu.Update(domain);
                }
            }
            context.SaveChanges();
            return model;
        }
    }
}
