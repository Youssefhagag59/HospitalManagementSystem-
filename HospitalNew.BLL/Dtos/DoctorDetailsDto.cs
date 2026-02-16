using HospitalNew.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalNew.BLL.Dtos
{
    public class DoctorDetailsDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public int RoomNb { get; set; }
        [Required, MaxLength(11)]
        public string PhoneNb { get; set; }
    }
}
