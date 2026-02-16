using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.DAL.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string HashedPassword { get; set; }

    }
}
