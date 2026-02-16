using System.ComponentModel.DataAnnotations;

namespace HospitalNew.BLL.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
