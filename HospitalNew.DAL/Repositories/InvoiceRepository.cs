using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.DAL.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();

        public InvoiceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int CalculateInvoicePrice()
        {
            return _random.Next(500, 3001);
        }

        public async Task<IEnumerable<Invoice>> GetDetails()
        {
            return await _context.Invoices
                            .Include(i => i.Appointment)
                            .ThenInclude(i => i.Doctor)
                            .ThenInclude(i => i.Specialty)
                            .Include(j => j.Appointment)
                            .ThenInclude(j => j.Patient)
                            .Where(i => i.Appointment.AppStatus != AppStatus.Cancelled)
                            .ToListAsync();
        }
    }
}
