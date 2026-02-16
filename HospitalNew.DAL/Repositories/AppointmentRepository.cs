using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.DAL.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetDetails()
        {
            return await _context.Appointments
                .Include(p=>p.Doctor)
                .ThenInclude(p=>p.Specialty)
                .Include(p=>p.Patient)
                .ToListAsync();
        }

        public bool IsValidAppointment(int id)
        {
            return _context.Appointments.Any(a => a.Id == id);
        }

        public bool IsValidDate(DateTime date)
        {
            if (date < DateTime.Now)
                return false;
            return true;
        }
    }
}
