using HospitalNew.BLL.Dtos;
using HospitalNew.DAL.Models;
using HospitalNew.DAL.Repositories;

namespace HospitalNew.BLL.Interfaces
{
    public interface IUsersService : IGenericService<User>
    {
        Task<User> DeleteUser(int  id);
        User IsValidUser(string name);
        string ValidateUser(UserDto dto);
        Task<User> AddUser(UserDetailsDto dto);
    }
}
