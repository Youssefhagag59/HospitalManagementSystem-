using HospitalNew.DAL.Data;
using HospitalNew.DAL.Interfaces;
using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public User IsValid(string name)
        {
            var user = _dbSet.SingleOrDefault(x => x.Name == name); 
            return user;
        } 
    }
}
