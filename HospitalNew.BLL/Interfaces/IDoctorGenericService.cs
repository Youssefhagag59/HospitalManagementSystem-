using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface IDoctorGenericService : IGenericService<Doctor>
    {
        Task<ServiceResult<Doctor>> UpdateDoctor(int id, DoctorDto doctor);
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> DeleteDoctorAsync(int id);
        Task<Doctor> AddDoctor(DoctorDto dto);
        bool IsValidDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDocID(int id);
        Task<IEnumerable<Doctor>> GetDoctorBySpecialty(int specialtyID);
        Task<IEnumerable<Doctor>> GetDoctorDetails();
    }
}
