using HospitalNew.DAL.Models;

namespace HospitalNew.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User IsValid(string name);
    }
}
