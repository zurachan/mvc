using mvc.Domain;
using mvc.Domain.Interfaces;
using mvc.Infrastructure;

namespace mvc.API.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenu();
        Menu SaveMenu(Menu model);
    }

    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMenuRepository _menuRepository;

        public MenuService(AppDbContext context, IUnitOfWork unitOfWork, IMenuRepository menuRepository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _menuRepository = menuRepository;
        }

        public List<Menu> GetMenu()
        {
            return [.. _menuRepository.List(x => !x.IsDeleted)];
        }

        public Menu SaveMenu(Menu model)
        {
            if (model.Id == 0) _context.Menu.Add(model);
            else
            {
                var domain = _context.Menu.FirstOrDefault(x => x.Id == model.Id);
                if (domain != null)
                {
                    domain.Name = model.Name;
                    domain.Path = model.Path;
                    domain.ParentId = model.ParentId;

                    _context.Menu.Update(domain);
                }
            }
            _context.SaveChanges();
            return model;
        }
    }
}
