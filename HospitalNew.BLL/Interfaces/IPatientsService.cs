using HospitalNew.BLL.Dtos;
using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface IPatientsService : IGenericService<Patient>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientID(int id);
        bool IsValidPatient(int id);
        Task<Patient> DeletePatient(int id);
        Task<Patient> UpdatePatientInfo(int id, PatientDto patient);
        Task<Patient> AddPatient(PatientDto dto);
    }
}
