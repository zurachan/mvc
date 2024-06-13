using mvc.Domains;

namespace mvc.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext _context = new AppDbContext();
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
