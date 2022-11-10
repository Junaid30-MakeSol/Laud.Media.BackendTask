using Laud.Media.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Laud.Media.Infrastructure.Persistence;

namespace Laud.Media.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public List<T> GetAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }


        public T Create(T obj)
        {
            _applicationDbContext.Set<T>().Add(obj);
            _applicationDbContext.SaveChanges();
            return obj;
        }

        public void Update(T obj)
        {
            _applicationDbContext.Set<T>().Attach(obj);
            _applicationDbContext.Entry(obj).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            T existing = _applicationDbContext.Set<T>().Find(id);
            _applicationDbContext.Set<T>().Remove(existing);
            _applicationDbContext.SaveChanges();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
