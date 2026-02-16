using System.Linq.Expressions;

namespace HospitalNew.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        T Update(T obj);
        T Delete(T obj);
        Task<T> Add(T obj);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate = null);
    }
}
