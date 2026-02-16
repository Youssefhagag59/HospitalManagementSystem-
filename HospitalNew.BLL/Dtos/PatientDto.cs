using HospitalNew.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalNew.BLL.Dtos
{
    public class PatientDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(11)]
        public string PhoneNb { get; set; }
        public string OldRecord { get; set; }
    }
}
