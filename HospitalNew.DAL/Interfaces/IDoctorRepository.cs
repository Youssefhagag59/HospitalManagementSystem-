using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        bool IsValid(int id);
        Task<IEnumerable<Doctor>> GetBySpecialty(int specialtyID);
        Task<IEnumerable<Appointment>> GetAppointments(int docID);
        Task<IEnumerable<Doctor>> GetDetails();
    }
}
