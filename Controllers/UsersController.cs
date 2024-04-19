using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Common;
using mvc.Domains;
using mvc.Models;

namespace mvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<JsonResult> GetUser()
        {
            var user = await _context.Users.ToListAsync();
            return new JsonResult(user);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Address,Username,RoleId")] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FullName.Trim(),
                    Address = model.Address.Trim(),
                };
                _context.Add(user);

                var salt = Guid.NewGuid().ToString();
                var account = new Account
                {
                    Username = model.Username.Trim(),
                    PasswordHash = Utils.EncryptedPassword("123456", salt),
                    PasswordSalt = salt,
                    User = user
                };
                _context.Add(account);

                var userRole = new UserRole
                {
                    User = user,
                    RoleId = model.RoleId,
                };
                _context.Add(userRole);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Account).FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var res = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName.Trim(),
                Address = user.Address.Trim(),
                AccountId = user.Account.Id,
                Username = user.Account.Username.Trim(),
            };

            return View(res);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Address,AccountId,Username")] UserViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        Id = model.Id,
                        FullName = model.FullName.Trim(),
                        Address = model.Address.Trim(),
                    };
                    _context.Update(user);

                    var account = await _context.Accounts.FindAsync(model.AccountId);
                    if (account != null)
                    {
                        account.Username = model.Username.Trim();
                    }
                    _context.Update(account);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(model.Id))
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
            return View(model);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.Users'  is null.");
            }
            var user = await _context.Users.Include(x => x.Account).FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                var account = await _context.Accounts.FindAsync(user.Account.Id);
                if (account != null)
                {
                    _context.Accounts.Remove(account);
                }

                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
