using HospitalNew.BLL.Dtos;
using HospitalNew.BLL.Helpers;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface IAppointmentsService : IGenericService<Appointment>
    {
        Task<ServiceResult<Appointment>> AddAppointment(AppointmentDto appointment);
        Task<Appointment> DeleteAppointment(int  id);
        Task<ServiceResult<Appointment>> UpdateAppointment(int id, AppointmentDto dto);
        bool IsValidDate(DateTime date);
        bool IsValidAppointment(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsDetails();
    }
}
