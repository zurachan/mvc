using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Domains;

namespace mvc.Controllers
{
    public class AppControllersController : Controller
    {
        private readonly AppDbContext _context;

        public AppControllersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppControllers
        public async Task<IActionResult> Index()
        {
            return _context.Controllers != null ?
                        View(await _context.Controllers.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Controllers'  is null.");
        }

        // GET: AppControllers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Controllers == null)
            {
                return NotFound();
            }

            var appController = await _context.Controllers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appController == null)
            {
                return NotFound();
            }

            return View(appController);
        }

        // GET: AppControllers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppControllers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ControllerName,ControllerPath")] AppController appController)
        {
            _context.Add(appController);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AppControllers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Controllers == null)
            {
                return NotFound();
            }

            var appController = await _context.Controllers.FindAsync(id);
            if (appController == null)
            {
                return NotFound();
            }
            return View(appController);
        }

        // POST: AppControllers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ControllerName,ControllerPath")] AppController appController)
        {
            if (id != appController.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(appController);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppControllerExists(appController.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AppControllers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Controllers == null)
            {
                return NotFound();
            }

            var appController = await _context.Controllers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appController == null)
            {
                return NotFound();
            }

            return View(appController);
        }

        // POST: AppControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Controllers == null)
            {
                return Problem("Entity set 'AppDbContext.Controllers'  is null.");
            }
            var appController = await _context.Controllers.FindAsync(id);
            if (appController != null)
            {
                _context.Controllers.Remove(appController);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppControllerExists(int id)
        {
            return (_context.Controllers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
