using HospitalNew.BLL.Dtos;
using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface ISpecialtiesService : IGenericService<Specialty>
    {
        Task<Specialty> GetSpecialtyById(int id);
        Task<Specialty> DeleteSpecialty(int id);
        Task<Specialty> UpdateSpecialty(int id,  SpecialtyDto specialty);
        Task<Specialty> AddSpecialty(SpecialtyDto dto);
        bool IsValidSpecialty(int id);
    }
}
