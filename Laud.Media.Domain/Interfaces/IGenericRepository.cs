namespace Laud.Media.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        T Create(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
