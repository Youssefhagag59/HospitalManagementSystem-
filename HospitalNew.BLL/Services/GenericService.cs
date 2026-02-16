using HospitalNew.DAL.Data;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.BLL.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<T> Add(T obj)
        {
            return await _genericRepository.Add(obj);
        }

        public T Delete(T obj)
        {
            return _genericRepository.Delete(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public T Update(T obj)
        {
            return _genericRepository.Update(obj);
        }
    }
}
