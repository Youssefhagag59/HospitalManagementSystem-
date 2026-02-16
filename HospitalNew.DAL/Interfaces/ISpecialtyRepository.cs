using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface ISpecialtyRepository : IGenericRepository<Specialty>
    {
        bool IsValid(int id);
    }
}
