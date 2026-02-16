using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.DAL.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor> , IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(int docID)
        {
            return await _context.Appointments
                .Where(x => x.DocId == docID)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetBySpecialty(int specialtyID)
        {
            return await _context.Doctors
                .Where(x => x.SpecialtyId == specialtyID)
                .Include(x => x.Specialty)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDetails()
        {
            return await _context.Doctors
                .Include(p=>p.Specialty)
                .ToListAsync();
        }

        public bool IsValid(int id)
        {
            return _context.Doctors.Any(x => x.Id == id);
        }
    }
}
