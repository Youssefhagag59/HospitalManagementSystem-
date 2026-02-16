using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<Appointment>> GetAppointments(int id);
        bool IsValid(int id);
    }
}
