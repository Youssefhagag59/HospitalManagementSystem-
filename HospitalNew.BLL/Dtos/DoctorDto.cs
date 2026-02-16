using HospitalNew.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.BLL.Dtos
{
    public class DoctorDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public int SpecialtyId { get; set; }
        public int RoomNb { get; set; }
        [Required, MaxLength(11)]
        public string PhoneNb { get; set; }
    }
}
