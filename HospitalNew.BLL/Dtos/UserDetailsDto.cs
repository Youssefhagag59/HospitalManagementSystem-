using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalNew.DAL.Models;
namespace HospitalNew.BLL.Dtos
{
    public class UserDetailsDto
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string HashedPassword { get; set; }

    }
}
