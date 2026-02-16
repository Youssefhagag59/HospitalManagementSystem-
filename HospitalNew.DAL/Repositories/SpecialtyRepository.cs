using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.DAL.Repositories
{
    public class SpecialtyRepository : GenericRepository<Specialty>, ISpecialtyRepository
    {
        private readonly AppDbContext _context;
        public SpecialtyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public bool IsValid(int id)
        {
            return _context.Specialties.Any(x => x.Id == id);
        }
    }
}
