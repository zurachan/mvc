using mvc.Domain;
using mvc.Infrastructure;

namespace mvc.API.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext _context;
        private GenericRepository<Menu> menuRepository;

        public GenericRepository<Menu> MenuRepository
        {
            get
            {
                if (menuRepository == null)
                {
                    menuRepository = new GenericRepository<Menu>(_context);
                }
                return menuRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
