using HospitalNew.DAL.Data;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Repositories;
using HospitalNew.DAL.Interfaces;

namespace HospitalNew.BLL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _Context;
        public IDoctorRepository doctorRepository { get; private set; }

        public IPatientRepository patientRepository { get; private set; }

        public IInvoiceRepository invoiceRepository { get; private set; }

        public ISpecialtyRepository specialtyRepository { get; private set; }

        public IAppointmentRepository appointmentRepository { get; private set; }

        public IUserRepository userRepository { get; private set; }
        public UnitOfWork(AppDbContext Context)
        {
            _Context = Context;
            doctorRepository = new DoctorRepository(_Context);
            patientRepository = new PatientRepository(_Context);
            invoiceRepository = new InvoiceRepository(_Context);
            userRepository = new UserRepository(_Context);
            specialtyRepository = new SpecialtyRepository(_Context);
            appointmentRepository = new AppointmentRepository(_Context);
        }
        public void Dispose()
        {
            _Context.Dispose();
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}
