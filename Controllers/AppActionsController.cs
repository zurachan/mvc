using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Domains;

namespace mvc.Controllers
{
    public class AppActionsController : Controller
    {
        private readonly AppDbContext _context;

        public AppActionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppActions
        public async Task<IActionResult> Index()
        {
            return _context.Actions.Include(x=>x.Controller) != null ?
                        View(await _context.Actions.Include(x=>x.Controller).ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Actions'  is null.");
        }

        // GET: AppActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Actions == null)
            {
                return NotFound();
            }

            var appAction = await _context.Actions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appAction == null)
            {
                return NotFound();
            }

            return View(appAction);
        }

        // GET: AppActions/Create
        public IActionResult Create()
        {
            ViewData["ControllerId"] = new SelectList(_context.Controllers, "Id", "ControllerName");
            return View();
        }

        // POST: AppActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActionName,ActionPath, ControllerId")] AppAction appAction)
        {
            _context.Add(appAction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AppActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Actions == null)
            {
                return NotFound();
            }

            var appAction = await _context.Actions.FindAsync(id);
            if (appAction == null)
            {
                return NotFound();
            }
            return View(appAction);
        }

        // POST: AppActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActionName,ActionPath")] AppAction appAction)
        {
            if (id != appAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppActionExists(appAction.Id))
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
            return View(appAction);
        }

        // GET: AppActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actions == null)
            {
                return NotFound();
            }

            var appAction = await _context.Actions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appAction == null)
            {
                return NotFound();
            }

            return View(appAction);
        }

        // POST: AppActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actions == null)
            {
                return Problem("Entity set 'AppDbContext.Actions'  is null.");
            }
            var appAction = await _context.Actions.FindAsync(id);
            if (appAction != null)
            {
                _context.Actions.Remove(appAction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppActionExists(int id)
        {
            return (_context.Actions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
