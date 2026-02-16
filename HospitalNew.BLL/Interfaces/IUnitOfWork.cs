using HospitalNew.DAL.Interfaces;

namespace HospitalNew.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IDoctorRepository doctorRepository { get; }
        public IPatientRepository patientRepository { get; }
        public IInvoiceRepository invoiceRepository { get; }
        public ISpecialtyRepository specialtyRepository { get; }
        public IAppointmentRepository appointmentRepository { get; }
        public IUserRepository userRepository { get; }
        
        void SaveChanges(); 
    }
}
