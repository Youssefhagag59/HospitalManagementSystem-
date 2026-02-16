using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        bool IsValidDate(DateTime date);
        bool IsValidAppointment(int  id);
        Task<IEnumerable<Appointment>> GetDetails();
    }
}
