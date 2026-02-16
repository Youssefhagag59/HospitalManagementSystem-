using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.DAL.Models
{
    public class Doctor : BaseEntity
    {
       
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public int SpecialtyId { get; set; }
        public int RoomNb { get; set; }
        [Required,MaxLength(11)]
        public string PhoneNb { get; set; }
        public Specialty Specialty { get; set; } 
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
