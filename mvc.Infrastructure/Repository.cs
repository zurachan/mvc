using Microsoft.EntityFrameworkCore;
using mvc.Domain.Base;
using mvc.Domain.Interfaces;
using System.Linq.Expressions;

namespace mvc.Infrastructure
{
    public class Repository<T>(DbFactory dbFactory) : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = dbFactory.DbContext.Set<T>());
        }

        public void Add(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else DbSet.Remove(entity);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
            }
            DbSet.Update(entity);
        }
    }
}
