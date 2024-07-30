using mvc.Domain.Interfaces;

namespace mvc.Infrastructure
{
    public class UnitOfWork(DbFactory dbFactory) : IUnitOfWork
    {
        public Task<int> CommitAsync()
        {
            return dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
