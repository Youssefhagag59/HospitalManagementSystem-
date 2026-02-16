using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalNew.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet; 
        public GenericRepository(AppDbContext context) 
        {
            _context = context;
            _dbSet = context.Set<T>(); 
        }
        public virtual async Task<T> Add(T obj) 
        {
            await _context.AddAsync(obj);
           await _context.SaveChangesAsync();
            return obj; 
        }

        public T Delete(T obj)
        {
            _dbSet.Remove(obj);
            return obj;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _dbSet.Where(predicate).ToList();

            return _dbSet.ToList(); 
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public  T Update(T obj)
        {
            _dbSet.Update(obj);
            return obj;
        }
    }
}
