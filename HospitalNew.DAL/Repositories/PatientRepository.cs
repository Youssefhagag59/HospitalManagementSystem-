using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.DAL.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(int id)
        {
            var apps = await _context.Appointments
                            .Where(x => x.PatientId == id)
                            .Include(x => x.Doctor)
                            .Include(x => x.Patient)
                            .ToListAsync();
            return apps;
        }

        public bool IsValid(int id)
        {
            return _context.Patients.Any(p => p.Id == id);
        }
        
    }
}
