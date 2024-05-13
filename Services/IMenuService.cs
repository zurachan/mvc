using mvc.Domains;

namespace mvc.Services
{
    public interface IMenuService
    {
        List<AppController> GetMenu();
        AppController SaveMenu(AppController model);
    }

    public class MenuService(AppDbContext context) : IMenuService
    {
        public List<AppController> GetMenu() => [.. context.Controllers];

        public AppController SaveMenu(AppController model)
        {
            if (model.Id == 0) context.Controllers.Add(model);
            else
            {
                var domain = context.Controllers.FirstOrDefault(x => x.Id == model.Id);
                if (domain != null)
                {
                    domain.ControllerName = model.ControllerName;
                    domain.ControllerPath = model.ControllerPath;
                    context.Controllers.Update(domain);
                }
            }
            context.SaveChanges();
            return model;
        }
    }
}
