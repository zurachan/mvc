using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Domains;

namespace mvc.Controllers
{
    public class PhanQuyenController : Controller
    {
        private readonly AppDbContext _context;

        public PhanQuyenController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            var controllers = _context.Controllers.ToList();
            var roleControllers = _context.RoleControllers.ToList();
            ViewBag.Roles = roles;
            ViewBag.Controllers = controllers;
            ViewBag.RoleControllers = roleControllers;
            return View();
        }

        [HttpPost]
        public JsonResult SaveRoleController(int roleId, int controllerId, bool state)
        {
            var exitRoleController = _context.RoleControllers.Include(x => x.Role).Include(x => x.Controller)
                .FirstOrDefault(x => x.RoleId == roleId && x.ControllerId == controllerId);

            if (state)
            {
                if (exitRoleController == null)
                {
                    var entity = new RoleController
                    {
                        RoleId = roleId,
                        ControllerId = controllerId,
                    };
                    _context.RoleControllers.Add(entity);
                }
                else
                {
                    return Json(new { Success = false, Message = "Đã tồn tại" });
                }
            }
            else
            {
                if (exitRoleController == null)
                {
                    return Json(new { Success = false, Message = "Không tồn tại" });
                }
                else
                {
                    _context.RoleControllers.Remove(exitRoleController);
                }
            }
            _context.SaveChanges();
            return Json(new { Success = true });
        }
    }
}
