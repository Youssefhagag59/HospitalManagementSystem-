using System.ComponentModel.DataAnnotations;

namespace HospitalNew.BLL.Dtos
{
    public class SpecialtyDto
    {
        [Required, MaxLength(50)]

        public string Name { get; set; }
    }
}
