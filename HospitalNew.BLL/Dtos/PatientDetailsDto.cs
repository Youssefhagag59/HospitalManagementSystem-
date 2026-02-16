using System.ComponentModel.DataAnnotations;

namespace HospitalNew.BLL.Dtos
{
    public class PatientDetailsDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNb { get; set; }
        public string OldRecord { get; set; }
    }
}
