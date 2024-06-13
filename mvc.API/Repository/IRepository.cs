using mvc.API.Models;
using mvc.Infrastructure;

namespace mvc.API.Repository
{
    public interface IRepository<T> where T : class
    {
        Response<List<T>> GetAll();
        Response<T> GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Response<List<T>> GetAll()
        {
            return new Response<List<T>>([.. context.Set<T>()]);
        }

        public Response<T> GetById(int id)
        {
            return new Response<T>(context.Set<T>().Find(id));
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
