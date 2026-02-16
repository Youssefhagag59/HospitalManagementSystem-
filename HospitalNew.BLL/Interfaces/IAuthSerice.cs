using HospitalNew.DAL.Models;

namespace HospitalNew.BLL.Interfaces
{
    public interface IAuthSerice
    {
        string GenerateToken (User user);
    }
}
